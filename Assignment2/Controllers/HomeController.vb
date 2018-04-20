Imports System.Data.Linq
Imports System.Web.Mvc

Namespace Controllers
    Public Class HomeController
        Inherits Controller
        Dim stringBuilder As StringBuilder
        Dim dataContext As DataClasses2DataContext = New DataClasses2DataContext
        ' GET: Home
        Function Index() As ActionResult
            Return View()
        End Function

        ' GET: Home/Create
        Function Create() As ActionResult
            Dim questions = From ques In DataContext.USER_QUSTN_LSTs Select ques
            ViewData("Questions") = sortQuestions(questions)
            Return View()
        End Function

        Public Function sortQuestions(questions As IQueryable(Of USER_QUSTN_LST)) As List(Of String)
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
                If Int(Session("loginAttempt")) >= 1 Then
                    loginAttempt = Session("loginAttempt")
                    loginAttempt = loginAttempt + 1
                    Session("loginAttempt") = loginAttempt
                End If
            Catch ex As Exception
                loginAttempt = 1
                Session("loginAttempt") = loginAttempt
            End Try
            If loginAttempt > 2 Then
                ModelState.AddModelError("error", "You failed 3 times. Your account has been locked.")
                Return View("Index")
            Else
                Try
                    Dim username As String = collection("username").ToString
                    Dim password As String = collection("password").ToString
                    'Dim questions = From ques In allquestion.USER_QUSTN_LSTs Select ques
                    Dim result = (From u In dataContext.USER_ACCOUNTs Select u Where u.USERNAME = username And u.PASSWORD = password).FirstOrDefault
                    Dim user As USER_ACCOUNT = New USER_ACCOUNT
                    If IsNothing(result) Then
                        ModelState.AddModelError("error", "Invalid username/password. You have " & (3 - loginAttempt) & " left")
                    Else
                        'Get only the details that're already in the application ie no password and security answer
                        user.FIRSTNAME = result.FIRSTNAME
                        user.LASTNAME = result.LASTNAME
                        user.USER_QA_TBs = result.USER_QA_TBs
                        user.USERID = result.USERID
                        Session("user") = user
                        Dim ques = From q In dataContext.USER_QA_TBs
                                   Join r In dataContext.USER_QUSTN_LSTs
                                       On q.QUESTIONID Equals r.QUESTIONID
                                   Where q.USERID = result.USERID
                                   Select r

                        Dim data As USER_QUSTN_LST = New USER_QUSTN_LST
                        For Each q In ques
                            data.QUESTION = q.QUESTION
                        Next
                        ViewData("securityQuestion") = data.QUESTION
                    End If
                    Return View("Security")
                Catch ex As Exception
                    ModelState.AddModelError("error", ex.Message)
                    Return View("Index")
                End Try
            End If
        End Function

        Public Function Security(ByVal collection As FormCollection) As ActionResult
            Return View("Index")
        End Function
    End Class
End Namespace