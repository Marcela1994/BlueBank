const Router = require('express');
const routerCuentas = Router();
var sql = require("mssql");
const config = require('../conexion');

routerCuentas.post('/cuenta', (req, res) => {
    console.log(req.body);
    const { pnombre, snombre, papellido, sapellido, documento, nrocuenta, clave, saldo } = req.body;

    // connect to your database
    sql.connect(config, function(err) {

        if (err) console.log(err);

        // create Request object
        var request = new sql.Request();

        // query to the database and get the records
        request.input('pNombre', sql.VarChar(30), pnombre);
        request.input('sNombre', sql.VarChar(30), snombre);
        request.input('pApellido', sql.VarChar(30), papellido);
        request.input('sApellido', sql.VarChar(30), sapellido);
        request.input('documento', sql.VarChar(30), documento);
        request.input('nroCta', sql.VarChar(30), nrocuenta);
        request.input('clave', sql.VarChar(30), clave);
        request.input('saldo', sql.VarChar(30), saldo);

        request.execute('insertarCliente', function(err, result) {

            if (err) console.log(err)

            // send records as a response
            res.json(result);

        });
    });
});

module.exports = routerCuentas;