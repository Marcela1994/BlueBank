const Router = require('express');
const routerClientes = Router();
var sql = require("mssql");
const config = require('../conexion');


routerClientes.get('/clientes', (req, res) => {
    // connect to your database
    sql.connect(config, function(err) {

        if (err) console.log(err);

        // create Request object
        var request = new sql.Request();

        // query to the database and get the records
        request.execute("datosClientes", function(err, result) {

            if (err) console.log(err)

            // send records as a response
            console.log('Resultado: ' + result.recordset);
            res.json(result);

        });
    });
});

routerClientes.get('/cliente/:cc', (req, res) => {
    // connect to your database
    sql.connect(config, function(err) {

        if (err) console.log(err);

        // create Request object
        var request = new sql.Request();

        // query to the database and get the records
        var cc = req.params.cc;
        console.log('Cedula: ' + cc);
        request.input('cedula', sql.VarChar(30), cc);
        var sqlQuery = 'select primer_nombre,segundo_nombre,primer_apellido,segungo_apellido from personas where documento = ' + cc;
        request.query(sqlQuery, function(err, result) {

            if (err) console.log(err)

            // send records as a response
            res.json(result.recordsets);

        });
    });
});

module.exports = routerClientes;