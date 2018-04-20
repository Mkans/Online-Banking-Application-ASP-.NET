Imports System.Web.Mvc

Namespace Controllers
    Public Class TransactionController
        Inherits Controller
        Dim dataContext As DataClasses2DataContext = New DataClasses2DataContext
        Dim user As USER_ACCOUNT
        ' GET: Transaction
        Function Index() As ActionResult
            user = Session("user")
            Dim creditTransaction = From q In dataContext.BANK_TRANSACTIONs
                                    Select q
                                    Where q.USERID = user.USERID And q.TRANSACTIONTYPE = "credit"

            Dim debitTransaction = From q In dataContext.BANK_TRANSACTIONs
                                   Select q
                                   Where q.USERID = user.USERID And q.TRANSACTIONTYPE = "debit"

            Dim creditTranscArray As ArrayList = New ArrayList
            For Each newAccount As BANK_TRANSACTION In creditTransaction
                creditTranscArray.Add(newAccount)
            Next
            Dim debitTranscArray As ArrayList = New ArrayList
            For Each newdebAccount As BANK_TRANSACTION In debitTransaction
                debitTranscArray.Add(newdebAccount)
            Next

            Session("creditTransaction") = creditTranscArray
            Session("debitTransaction") = debitTranscArray
            Return View()
        End Function

        ' GET: Transaction/Details/5
        Function Details(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' GET: Transaction/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Transaction/Create
        <HttpPost()>
        Function Create(ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add insert logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Transaction/Edit/5
        Function Edit(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' POST: Transaction/Edit/5
        <HttpPost()>
        Function Edit(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add update logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Transaction/Delete/5
        Function Delete(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' POST: Transaction/Delete/5
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