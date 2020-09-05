Imports System.Data
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Linq
Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports System.Web.Http.Description
Imports BlueBank_apis

Namespace Controllers
    Public Class movimientosController
        Inherits System.Web.Http.ApiController

        Private db As New BlueBankEntities

        ' GET: api/movimientos
        Function Getmovimientos() As IQueryable(Of movimientos)
            Return db.movimientos
        End Function

        ' GET: api/movimientos/5
        <ResponseType(GetType(movimientos))>
        Function Getmovimientos(ByVal id As Integer) As IHttpActionResult
            Dim movimientos As movimientos = db.movimientos.Find(id)
            If IsNothing(movimientos) Then
                Return NotFound()
            End If

            Return Ok(movimientos)
        End Function

        ' PUT: api/movimientos/5
        <ResponseType(GetType(Void))>
        Function Putmovimientos(ByVal id As Integer, ByVal movimientos As movimientos) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = movimientos.id_movimiento Then
                Return BadRequest()
            End If

            db.Entry(movimientos).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (movimientosExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/movimientos
        <ResponseType(GetType(movimientos))>
        Function Postmovimientos(ByVal movimientos As movimientos) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.movimientos.Add(movimientos)

            Try
                db.SaveChanges()
            Catch ex As DbUpdateException
                If (movimientosExists(movimientos.id_movimiento)) Then
                    Return Conflict()
                Else
                    Throw
                End If
            End Try

            Return CreatedAtRoute("DefaultApi", New With {.id = movimientos.id_movimiento}, movimientos)
        End Function

        ' DELETE: api/movimientos/5
        <ResponseType(GetType(movimientos))>
        Function Deletemovimientos(ByVal id As Integer) As IHttpActionResult
            Dim movimientos As movimientos = db.movimientos.Find(id)
            If IsNothing(movimientos) Then
                Return NotFound()
            End If

            db.movimientos.Remove(movimientos)
            db.SaveChanges()

            Return Ok(movimientos)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function movimientosExists(ByVal id As Integer) As Boolean
            Return db.movimientos.Count(Function(e) e.id_movimiento = id) > 0
        End Function
    End Class
End Namespace