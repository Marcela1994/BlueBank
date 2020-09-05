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
    Public Class cuentasController
        Inherits System.Web.Http.ApiController

        Private db As New BlueBankEntities

        ' GET: api/cuentas
        Function Getcuentas() As IQueryable(Of cuentas)
            Return db.cuentas
        End Function

        ' GET: api/cuentas/5
        <ResponseType(GetType(cuentas))>
        Function Getcuentas(ByVal id As String) As IHttpActionResult
            Dim cuentas As cuentas = db.cuentas.Find(id)
            If IsNothing(cuentas) Then
                Return NotFound()
            End If

            Return Ok(cuentas)
        End Function

        ' PUT: api/cuentas/5
        <ResponseType(GetType(Void))>
        Function Putcuentas(ByVal id As String, ByVal cuentas As cuentas) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = cuentas.nro_cuenta Then
                Return BadRequest()
            End If

            db.Entry(cuentas).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (cuentasExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/cuentas
        <ResponseType(GetType(cuentas))>
        Function Postcuentas(ByVal cuentas As cuentas) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.cuentas.Add(cuentas)

            Try
                db.SaveChanges()
            Catch ex As DbUpdateException
                If (cuentasExists(cuentas.nro_cuenta)) Then
                    Return Conflict()
                Else
                    Throw
                End If
            End Try

            Return CreatedAtRoute("DefaultApi", New With {.id = cuentas.nro_cuenta}, cuentas)
        End Function

        ' DELETE: api/cuentas/5
        <ResponseType(GetType(cuentas))>
        Function Deletecuentas(ByVal id As String) As IHttpActionResult
            Dim cuentas As cuentas = db.cuentas.Find(id)
            If IsNothing(cuentas) Then
                Return NotFound()
            End If

            db.cuentas.Remove(cuentas)
            db.SaveChanges()

            Return Ok(cuentas)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function cuentasExists(ByVal id As String) As Boolean
            Return db.cuentas.Count(Function(e) e.nro_cuenta = id) > 0
        End Function
    End Class
End Namespace