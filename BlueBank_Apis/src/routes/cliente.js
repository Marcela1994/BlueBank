const express = require('express');
const cliente = express.Router();
const consulta = require('./database');

consulta = new sql.Request().query('select * from personas');


module.exports = cliente;