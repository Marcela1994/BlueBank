const Router = require('express');
const routerClientes = Router();
const config = require('../conexion');

var sql = require("mssql");
var log4js = require("log4js");
var logger = log4js.getLogger();

log4js.configure({
    appenders: { clientes: { type: "file", filename: "clientes.log" } },
    categories: { default: { appenders: ["clientes"], level: "debug" } }
});
logger.level = "fatal";


routerClientes.get('/clientes', (req, res) => {
    // connect to your database
    sql.connect(config, function(err) {

        if (err) logger.error("Se genero un error al abrir la conexion");

        // create Request object
        var request = new sql.Request();

        // query to the database and get the records
        request.execute("datosClientes", function(err, result) {

            if (err) logger.error("Se genero un error al ejecutar el procedimiento datosClientes");

            // send records as a response
            console.log('Resultado: ' + result.recordset);
            logger.debug("GET -> /api/clientes");
            logger.debug("Se realizo la consulta de los clientes correctamente...");
            res.json(result.recordset);

        });
    });
});

routerClientes.get('/cliente/:cc', (req, res) => {
    // connect to your database
    sql.connect(config, function(err) {

        if (err) logger.error("Se genero un error al abrir la conexion");

        // create Request object
        var request = new sql.Request();

        // query to the database and get the records
        var cc = req.params.cc;
        console.log('Cedula: ' + cc);
        request.input('cedula', sql.VarChar(30), cc);
        var sqlQuery = 'select primer_nombre,segundo_nombre,primer_apellido,segungo_apellido from personas where documento = ' + cc;
        request.query(sqlQuery, function(err, result) {

            if (err) logger.error("Se genero un error al realizar la consulta");

            // send records as a response
            logger.debug("GET -> /api/cliente/:cc");
            logger.debug("Se realizo la consulta del cliente con cedula " + cc);
            res.json(result.recordsets);

        });
    });
});

module.exports = routerClientes;