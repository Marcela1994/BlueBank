const express = require('express');
const app = express();
const morgan = require('morgan');
const routerClientes = require('./routes/clientes');
const routerCuentas = require('./routes/cuenta');

// settings
app.set('port', process.env.PORT || 3000);
app.set('json spaces', 2);

// middleware
app.use(morgan('dev'));
app.use(express.urlencoded({ extended: false }));
app.use(express.json());

// router
app.use('/api', routerClientes);
app.use('/api', routerCuentas);

// starting the server
app.listen(app.get('port'), () => {
    console.log('Servidor inicializado');
});