const express = require('express');
const app = express();
const morgan = require('morgan');
const bodyParser = require('body-parser');

const routerClientes = require('./routes/clientes');
const routerCuentas = require('./routes/cuenta');

// settings
app.set('port', process.env.PORT || 3000);
app.set('json spaces', 2);

// middleware
var jsonParser = bodyParser.json();
var urlencodedParser = bodyParser.urlencoded({ extended: false });

app.use((req, res, next) => {
    res.header('Access-Control-Allow-Origin', '*');
    next();
  });

app.use(morgan('dev'));
// app.use(express.urlencoded({ extended: false }));
// app.use(express.json());
app.use(jsonParser);
app.use(urlencodedParser);

// router
app.use('/api', routerClientes);
app.use('/api', routerCuentas);

// starting the server
app.listen(app.get('port'), () => {
    console.log('Servidor inicializado en puerto ' + app.get('port'));
});