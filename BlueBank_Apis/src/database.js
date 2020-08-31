const express = require('express');
const conexion = express.Router();
const sql = require('mssql');
const consulta = require('./routes/cliente');

console.log("Hello world, This is an app to connect to sql server.");
var config = {
        "user": "deisycuellarg", 
        "password": "Deftones92*",
        "server": "deisycuellarg.database.windows.net", 
        "database": "BlueBank ",
        "options": {
            "encrypt": true
        }
      }

sql.connect(config, err => { 
    if(err){
        throw err ;
    }
    console.log("Connection Successful !");
    newConsulta = {consulta};

    new sql.Request().query(newConsulta, (err, result) => {
        //handle err
        console.dir(result)
        // This example uses callbacks strategy for getting results.
    })
        
});

sql.on('error', err => {
    // ... error handler 
    console.log("Sql database connection error " ,err);
})

module.exports = conexion;