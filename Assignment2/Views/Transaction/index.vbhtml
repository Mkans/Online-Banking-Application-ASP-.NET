@ModelType Assignment2.BANK_TRANSACTION

@Code
	ViewData("Title") = "Transaction History - M.R Banking App"
End Code
<script>
	$(document).ready(function () {
		$('#creditTable').dataTable({
			"searching": true
		});
		$('#debitTable').dataTable({
			"searching": true
		});
		$('#debit').hide();
		$('#accountToggle').on('change', function () {
			if (this.value == '1')
			{
				$("#credit").show();
				$('#debit').hide();
			}
			else {
				$("#credit").hide();
				$('#debit').show();
			}
		});
	});
</script>
	<select id="accountToggle">
		<option value="null">Select your account</option>
		<option value="0">Debit</option>
		<option value="1">Credit</option>
	</select>
<div id ="credit" style="padding-top:5%;">
	<table id="creditTable" name="creditTable">
		<thead>
			<tr>
				<th>Transaction Type</th>
				<th>Amount</th>
				<th>Memo</th>
				<th>Transaction Date</th>
			</tr>
			</thead>
		<tbody>
			@For Each a As BANK_TRANSACTION In Session("creditTransaction")
		@<tr>
			<td>@(a.TRANSACTIONTYPE)</td>
			<td>@(a.AMOUNT)</td>
			<td>@(a.MEMODESCRIPTION)</td>
			<td>@(a.CREATEDDATE)</td>
		</tr>
			Next a
		</tbody>	
</table>
</div>
<div id ="debit" style="padding-top:5%;">
	<table id="debitTable" name="debitTable">
		<thead>
			<tr>
				<th>Transaction Type</th>
				<th>Amount</th>
				<th>Memo</th>
				<th>Transaction Date</th>
			</tr>
		</thead>
		<tbody>
			@For Each a As BANK_TRANSACTION In Session("debitTransaction")
				@<tr>
					<td>@(a.TRANSACTIONTYPE)</td>
					<td>@(a.AMOUNT)</td>
					<td>@(a.MEMODESCRIPTION)</td>
					<td>@(a.CREATEDDATE)</td>
				</tr>
			Next a
		</tbody>
	</table>
</div>
<p class="message">@Html.ActionLink("Back to Home", "Index", "User")</p>