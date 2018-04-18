Imports System.Data.Linq
Imports System.Web.Mvc

Namespace Controllers
    Public Class HomeController
        Inherits Controller
        Dim stringBuilder As StringBuilder
        ' GET: Home
        Function Index() As ActionResult
            Return View()
        End Function

        ' GET: Home/Details/5
        Function Details(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' GET: Home/Create
        Function Create() As ActionResult
            Dim allquestion As DataClasses2DataContext = New DataClasses2DataContext
            Dim questions = From ques In allquestion.USER_QUSTN_LSTs Select ques
            ViewData("Questions") = sortData(questions)
            Return View()
        End Function

        Public Function sortData(questions As IQueryable(Of USER_QUSTN_LST)) As List(Of String)
            Dim qList As List(Of String) = New List(Of String)
            stringBuilder = New StringBuilder()
            For Each question In questions
                qList.Add(question.QUESTION)
            Next
            Return qList
        End Function

        ' POST: Home/Create
        <HttpPost()>
        Function Create(ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add insert logic here
                Dim firstName As String = collection("FIRSTNAME").ToString
                Dim lastName As String = collection("LASTNAME").ToString
                Dim password As String = collection("PASSWORD").ToString
                Dim confirmPassword As String = collection("confirmpassword").ToString
                Dim emailAddress As String = collection("EMAIL").ToString
                Dim sQuestion As String = collection("secQuestion").ToString
                Dim sAnswer As String = collection("secanswer").ToString
                Dim accType As String = collection("accType").ToString
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function
        <HttpPost()>
        Public Function Login(ByVal collection As FormCollection) As ActionResult
            Dim loginAttempt As Integer
            Try
                If Int(Session("loginAttempt")) >= 0 Then
                    loginAttempt = Session("loginAttempt")
                    loginAttempt = loginAttempt + 1
                    Session("loginAttempt") = loginAttempt
                End If
            Catch ex As Exception
                loginAttempt = 0
                Session("loginAttempt") = loginAttempt
            End Try
            Try
                Dim username As String = collection("username").ToString
                Dim password As String = collection("password").ToString
                Dim text As String = username + password
                Return RedirectToAction("Index")
            Catch ex As Exception
                Return RedirectToAction("Index")
            End Try
        End Function

        ' GET: Home/Edit/5
        Function Edit(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' POST: Home/Edit/5
        <HttpPost()>
        Function Edit(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add update logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Home/Delete/5
        Function Delete(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' POST: Home/Delete/5
        <HttpPost()>
        Function Delete(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add delete logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function
    End Class
End Namespace