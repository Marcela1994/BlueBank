const express = require('express');
const app = express();
const cliente = require('./routes/cliente');
const conex = require('./database');

// Settings
app.set('port', process.env.port || 3000)

// Middlewares
app.use(express.json());

//Routes
app.use(cliente);
app.use(conex);

//Starting the server
app.listen(app.get('port'), () => {
    console.log('server on port', app.get('port'));
});