@ModelType Assignment2.BANK_ACCOUNT
@Code
	ViewData("Title") = "My Account - M.R Banking App"
End Code
<div>
	<h2>Accounts:</h2>
	@Html.ValidationSummary(False, "", New With {.class = "text-danger"})<table>
		<tr>
			<th>Account Type</th>
			<td>Balance</td>
		</tr>
		@For Each m As BANK_ACCOUNT In Session("validAccounts")
			@<tr>
				<th>@(m.ACCOUNTTYPE)</th>
				<td>@(m.BALANCE)</td>
			</tr>
		Next m
	</table>
	<h2>Blocked Accounts</h2>
	<table>
		<tr>
			<th>Account Type</th>
			<td>Balance</td>
		</tr>
		@For Each m As BANK_ACCOUNT In Session("blockedAccounts")
			@<tr>
				<th>@(m.ACCOUNTTYPE)</th>
				<td>@(m.BALANCE)</td>
			</tr>
		Next m
	</table>
	<p>
		@Html.ActionLink("Add an account", "Create", "User", New With {.area = ""}) |
		<a href="../Transaction/Index" class="elements"><span>Transaction</span></a> |
		<a href="../Transaction/Create" class="elements"><span>Make a transaction</span></a>
	</p>
	
</div>
