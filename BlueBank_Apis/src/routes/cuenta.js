const Router = require('express');
const routerCuentas = Router();
var sql = require("mssql");
const config = require('../conexion');
var log4js = require("log4js");
var logger = log4js.getLogger();

log4js.configure({
    appenders: { cuentas: { type: "file", filename: "cuentas.log" } },
    categories: { default: { appenders: ["cuentas"], level: "debug" } }
});
logger.level = "debug";

//Insertar un nuevo cliente
routerCuentas.post('/cuenta', (req, res) => {
    console.log(req.body);
    const { pnombre, snombre, papellido, sapellido, documento, nrocuenta, clave, saldo } = req.body;

    // connect to your database
    sql.connect(config, function (err) {

        if (err) logger.error("Se genero un error al abrir la conexion");

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

        request.execute('insertarCliente', function (err, result) {

            if (err) logger.error("Se genero un error al ejecutar el procedimiento insertarCliente");

            // send records as a response
            logger.debug("GET -> /api/cuenta");
            logger.debug("Se realizo la insercion del nuevo cliente correctamente...");
            res.json(result);

        });
    });
});


//realizar un retiro 
routerCuentas.post('/cuentaRetiro', (req, res) => {
    console.log(req.body);
const {valor, cuenta, pin} = req.body;

    // connect to your database
    sql.connect(config, function (err) {
        if (err) logger.error("Se genero un error al abrir la conexion");

        // create Request object
        var request = new sql.Request();

        // query to the database and get the records

        console.log('valor a retirar: ' + valor);
        console.log('cuenta: ' + cuenta);
        console.log('clave: ' + pin);

        request.input('cuenta', sql.VarChar(10), cuenta);
        request.input('valor', sql.Numeric(9, 2), valor);
        request.input('pin', sql.VarChar(4), pin);

        request.execute('retiro', function (err, result) {
            if (err) logger.error("Se genero un error al ejecutar el procedimiento retiro");


            // send records as a response
            console.log('Respuesta ' + result);
            logger.debug("GET -> /api/cuentaRetiro");
            logger.debug("Se realizo el retiro de la cuenta correctamente...");
            res.json(result.recordset);
        });
    });
});



//realizar una consignacion 
routerCuentas.post('/cuentaConsignacion', (req, res) => {
    console.log(req.body);
const {valor, cuenta} = req.body;

    // connect to your database
    sql.connect(config, function (err) {
        if (err) logger.error("Se genero un error al abrir la conexion");

        // create Request object
        var request = new sql.Request();

        // query to the database and get the records

        console.log('saldo: ' + valor);
        console.log('cuenta: ' + cuenta);

        request.input('cuenta', sql.VarChar(10), cuenta);
        request.input('valor', sql.Numeric(9, 2), valor);

        request.execute('consignacion', function (err, result) {
            if (err) logger.error("Se genero un error al ejecutar el procedimiento cuentaConsignacion");

            // send records as a response
            logger.debug("GET -> /api/cuentaConsignacion");
            logger.debug("Se realizo la consignacion a la cuenta correctamente...");
            res.json(result);
        });
    });
});


//realizar una consulta 
routerCuentas.post('/cuenta/consultar', (req, res) => {

    sql.connect(config, function (err) {
        if (err) logger.error("Se genero un error al abrir la conexion");

        // create Request object
        var request = new sql.Request();

        // query to the database and get the records

        const {cuenta, pin} = req.body;

        request.input('cuenta', sql.VarChar(10), cuenta);
        request.input('pin', sql.VarChar(4), pin);

        request.execute('consultaSaldo', function (err, result) {
            if (err) logger.error("Se genero un error al ejecutar el procedimiento consultaSaldo");

            // send records as a response
            if(result.recordset.length>0){
                logger.debug("GET -> /api/cuenta/consultar");
                logger.debug("Se realizo la consulta de las cuentas correctamente...");
                res.status(200).json(result.recordset);
            }else{
                res.status(404).json({"error": "No se encontraron datos para la cuenta ingresada, valide la cuenta y pin"});
            }
        });
    }); 
    
});






module.exports = routerCuentas;