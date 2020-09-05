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
    Public Class historico_movimientosController
        Inherits System.Web.Http.ApiController

        Private db As New BlueBankEntities

        ' GET: api/historico_movimientos
        Function Gethistorico_movimientos() As IQueryable(Of historico_movimientos)
            Return db.historico_movimientos
        End Function

        ' GET: api/historico_movimientos/5
        <ResponseType(GetType(historico_movimientos))>
        Function Gethistorico_movimientos(ByVal id As String) As IHttpActionResult
            Dim historico_movimientos As historico_movimientos = db.historico_movimientos.Find(id)
            If IsNothing(historico_movimientos) Then
                Return NotFound()
            End If

            Return Ok(historico_movimientos)
        End Function

        ' PUT: api/historico_movimientos/5
        <ResponseType(GetType(Void))>
        Function Puthistorico_movimientos(ByVal id As String, ByVal historico_movimientos As historico_movimientos) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = historico_movimientos.documento Then
                Return BadRequest()
            End If

            db.Entry(historico_movimientos).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (historico_movimientosExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/historico_movimientos
        <ResponseType(GetType(historico_movimientos))>
        Function Posthistorico_movimientos(ByVal historico_movimientos As historico_movimientos) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.historico_movimientos.Add(historico_movimientos)

            Try
                db.SaveChanges()
            Catch ex As DbUpdateException
                If (historico_movimientosExists(historico_movimientos.documento)) Then
                    Return Conflict()
                Else
                    Throw
                End If
            End Try

            Return CreatedAtRoute("DefaultApi", New With {.id = historico_movimientos.documento}, historico_movimientos)
        End Function

        ' DELETE: api/historico_movimientos/5
        <ResponseType(GetType(historico_movimientos))>
        Function Deletehistorico_movimientos(ByVal id As String) As IHttpActionResult
            Dim historico_movimientos As historico_movimientos = db.historico_movimientos.Find(id)
            If IsNothing(historico_movimientos) Then
                Return NotFound()
            End If

            db.historico_movimientos.Remove(historico_movimientos)
            db.SaveChanges()

            Return Ok(historico_movimientos)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function historico_movimientosExists(ByVal id As String) As Boolean
            Return db.historico_movimientos.Count(Function(e) e.documento = id) > 0
        End Function
    End Class
End Namespace