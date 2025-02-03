// app.js or server.js

const express = require('express');
const bodyParser = require('body-parser');
const paypal = require('@paypal/checkout-server-sdk');
const app = express();
const port = 3000;

// Set up the PayPal environment with your credentials
const environment = new paypal.core.SandboxEnvironment(
    'YOUR_PAYPAL_CLIENT_ID',  // Replace with your PayPal client ID
    'YOUR_PAYPAL_SECRET'      // Replace with your PayPal secret
);
const client = new paypal.core.PayPalHttpClient(environment);

// Middleware to parse JSON bodies
app.use(bodyParser.json());

// Endpoint to create PayPal order for donations
app.post('/api/create_paypal_donation_order', async (req, res) => {
    const { amount, currency = 'USD' } = req.body;  // Amount and currency are passed in the request

    // Create PayPal order request
    const request = new paypal.orders.OrdersCreateRequest();
    request.prefer('return=representation');
    request.requestBody({
        intent: 'CAPTURE',  // We're capturing the payment after approval
        purchase_units: [
            {
                amount: {
                    currency_code: currency,  // Currency code, defaults to USD
                    value: amount,            // Donation amount
                },
            },
        ],
    });

    try {
        // Create the PayPal order
        const order = await client.execute(request);
        // Find the approval URL to redirect the user to PayPal for approval
        const approvalUrl = order.result.links.find(link => link.rel === 'approve').href;
        res.json({ approvalUrl });  // Send approval URL to frontend
    } catch (error) {
        console.error(error);
        res.status(500).json({ error: 'Error creating PayPal donation order' });
    }
});

// Endpoint to capture the PayPal donation after approval
app.post('/api/capture_paypal_donation_payment', async (req, res) => {
    const { orderID } = req.body;  // Order ID received after PayPal approval

    const request = new paypal.orders.OrdersCaptureRequest(orderID);
    request.requestBody({});

    try {
        // Capture the payment from PayPal
        const capture = await client.execute(request);
        res.json({ status: capture.result.status, paymentDetails: capture.result });
    } catch (error) {
        console.error(error);
        res.status(500).json({ error: 'Error capturing PayPal donation payment' });
    }
});

// Start the server
app.listen(port, () => {
    console.log(`Server running on http://localhost:${port}`);
});
