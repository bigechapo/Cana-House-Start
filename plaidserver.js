app.post('/api/exchange_public_token', async function (
    request,
    response,
    next,
) {
    const publicToken = request.body.public_token;
    try {
        const response = await client.itemPublicTokenExchange({
            public_token: publicToken,
        });

        // These values should be saved to a persistent database and
        // associated with the currently signed-in user
        const accessToken = response.data.access_token;
        const itemID = response.data.item_id;

        res.json({ public_token_exchange: 'complete' });
    } catch (error) {
        // handle error
    }
});
