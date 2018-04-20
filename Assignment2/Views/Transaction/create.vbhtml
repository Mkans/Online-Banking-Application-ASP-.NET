@ModelType Assignment2.BANK_TRANSACTION
@Code
	ViewData("Title") = "Make a transaction"
End Code
<div class="padding-top-8">
	<h2 class="hometext">Make a transaction</h2>
	@Using (Html.BeginForm())
		@Html.AntiForgeryToken()

		@<div class="form">
	@Html.ValidationSummary(True, "", New With {.class = "text-danger"})

	<div class="form-group">

		<select name="accType">
			<option value="">Select an account</option>
			@For Each m As BANK_ACCOUNT In Session("validAccounts")
				@<option value="@(m.ACCOUNTTYPE)">@(m.ACCOUNTTYPE)</option>
			Next m
		</select><br />
		<select name="transactionType">
			<option value="">Select a transaction type</option>
			<option value="credit">Credit</option>
			<option value="debit">Debit</option>
		</select>
		@Html.EditorFor(Function(model) model.AMOUNT, New With {.htmlAttributes = New With {.class = "form-control gray-background input-decorate", .placeholder = "amount"}})
		@Html.ValidationMessageFor(Function(model) model.AMOUNT, "", New With {.class = "text-danger"})

		@Html.EditorFor(Function(model) model.MEMODESCRIPTION, New With {.htmlAttributes = New With {.class = "form-control gray-background input-decorate", .placeholder = "memo (optional)"}})
		@Html.ValidationMessageFor(Function(model) model.MEMODESCRIPTION, "", New With {.class = "text-danger"})

		<button type="submit" value="Create">Confirm</button>
	</div>
	<p class="message">@Html.ActionLink("Back to Home", "Index", "User")</p>
</div>
	End Using
	</div>