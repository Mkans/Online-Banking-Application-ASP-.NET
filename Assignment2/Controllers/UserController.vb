Imports System.Web.Mvc

Namespace Controllers
    Public Class UserController
        Inherits Controller
        Dim dataContext As DataClasses2DataContext = New DataClasses2DataContext
        Dim user As USER_ACCOUNT

        ' GET: User
        Function Index() As ActionResult
            If Session("IsValidUser") Then
                'Account information
                user = Session("user")
                Dim accounts = From account In dataContext.BANK_ACCOUNTs
                               Where account.USERID = user.USERID
                               Select account

                Dim accountList As ArrayList = New ArrayList
                Dim blockedList As ArrayList = New ArrayList
                For Each account In accounts
                    Dim ac As BANK_ACCOUNT = New BANK_ACCOUNT
                    ac.ACCOUNTID = account.ACCOUNTID
                    ac.ACCOUNTTYPE = account.ACCOUNTTYPE
                    ac.BALANCE = account.BALANCE
                    If account.ISACTIVE Then
                        accountList.Add(ac)
                    Else
                        blockedList.Add(ac)
                    End If
                Next
                Session("validAccounts") = accountList
                Session("blockedAccounts") = blockedList
                Return View()
            Else
                ModelState.AddModelError("error", "Login to access other features.")
                Return RedirectToAction("Index", "Home")
            End If

        End Function

        ' GET: User/Details/5
        Function Details(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' GET: User/Create
        Function Create() As ActionResult
            user = Session("user")
            Dim userAccounts = From a In dataContext.BANK_ACCOUNTs
                               Where a.USERID = user.USERID
                               Select a
            If (userAccounts.Count = 2) Then
                ModelState.AddModelError("error", "You have both chequin and saving accounts.")
                Return View("Index")
            Else
                Dim remAccount As String = vbNull
                For Each account As BANK_ACCOUNT In userAccounts
                    If (account.ACCOUNTTYPE).Equals("savings") Then
                        remAccount = "chequing"
                    Else
                        remAccount = "savings"
                    End If
                Next
                ViewData("remAccount") = remAccount
            End If
            Return View("Create")
        End Function

        ' POST: User/Create
        <HttpPost()>
        Function Create(ByVal collection As FormCollection) As ActionResult
            user = Session("user")
            Try
                Dim newAccType As String
                newAccType = collection("accType").ToString
                If newAccType.Equals("") Then
                    ModelState.AddModelError("error", "Select an account type from the list.")
                    Return View("Create")
                Else
                    Dim newAccount As New BANK_ACCOUNT With
                        {
                            .ACCOUNTID = 2,
                            .ACCOUNTTYPE = newAccType,
                            .BALANCE = 0.0,
                            .ISACTIVE = True,
                            .USERID = user.USERID
                        }
                    dataContext.BANK_ACCOUNTs.InsertOnSubmit(newAccount)
                    dataContext.SubmitChanges()
                    ModelState.AddModelError("Success", "Account created")
                    Return View("Index")
                End If
            Catch e As Exception
                ModelState.AddModelError("Exception", e.Message)
                Return View("Create")
            End Try
        End Function

        ' GET: User/Edit/5
        Function Edit(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' POST: User/Edit/5
        <HttpPost()>
        Function Edit(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add update logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: User/Delete/5
        Function Delete(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' POST: User/Delete/5
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