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
    Public Class personasController
        Inherits System.Web.Http.ApiController

        Private db As New BlueBankEntities

        ' GET: api/personas
        Function Getpersonas() As IQueryable(Of personas)
            Return db.personas
        End Function

        ' GET: api/personas/5
        <ResponseType(GetType(personas))>
        Function Getpersonas(ByVal id As String) As IHttpActionResult
            Dim personas As personas = db.personas.Find(id)
            If IsNothing(personas) Then
                Return NotFound()
            End If

            Return Ok(personas)
        End Function

        ' PUT: api/personas/5
        <ResponseType(GetType(Void))>
        Function Putpersonas(ByVal id As String, ByVal personas As personas) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = personas.documento Then
                Return BadRequest()
            End If

            db.Entry(personas).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (personasExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/personas
        <ResponseType(GetType(personas))>
        Function Postpersonas(ByVal personas As personas) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.personas.Add(personas)

            Try
                db.SaveChanges()
            Catch ex As DbUpdateException
                If (personasExists(personas.documento)) Then
                    Return Conflict()
                Else
                    Throw
                End If
            End Try

            Return CreatedAtRoute("DefaultApi", New With {.id = personas.documento}, personas)
        End Function

        ' DELETE: api/personas/5
        <ResponseType(GetType(personas))>
        Function Deletepersonas(ByVal id As String) As IHttpActionResult
            Dim personas As personas = db.personas.Find(id)
            If IsNothing(personas) Then
                Return NotFound()
            End If

            db.personas.Remove(personas)
            db.SaveChanges()

            Return Ok(personas)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function personasExists(ByVal id As String) As Boolean
            Return db.personas.Count(Function(e) e.documento = id) > 0
        End Function
    End Class
End Namespace