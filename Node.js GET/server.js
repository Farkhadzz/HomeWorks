const express = require('express');
const app = express();
const fs = require('fs');
const port = 3000;

app.get('/users', (req, res) => {
    fs.readFile('users.json', 'utf8', (err, data) => {
        if (err) {
            res.status(500).send('Error reading file');
            return;
        }
        res.header("Content-Type", "application/json");
        res.send(data);
    });
});

app.listen(port, () => {
    console.log(`Server running at http://localhost:${port}`);
});