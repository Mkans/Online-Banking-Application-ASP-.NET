<!DOCTYPE html>
<html>
<head>
	<meta charset="utf-8" />
	<meta name="viewport" content="width=device-width, initial-scale=1.0">
	<title>@ViewBag.Title</title>
	<link href="~/Content/Home.css" rel="stylesheet" type="text/css" />
	<link href="~/Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
	<link href="~/Content/Site.css" rel="stylesheet" type="text/css" />
	<script src="~/Scripts/modernizr-2.6.2.js"></script>

</head>
<body>
	<div class="navbar navbar-inverse navbar-fixed-top">
		<div class="container">
			<div class="navbar-header">
				<button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
					<span class="icon-bar"></span>
					<span class="icon-bar"></span>
					<span class="icon-bar"></span>
				</button>
				@Html.ActionLink("M.R Banking App", "Index", "Home", New With {.area = ""}, New With {.class = "navbar-brand"})
			</div>
			<div class="navbar-collapse collapse">
				<ul class="nav navbar-nav"></ul>
			</div>
		</div>
	</div>

	<div class="container body-content">
		@RenderBody()
		<footer class="headerfooter">
			<hr />
			<p>&copy; M.R Banking App -  @DateTime.Now.Year </p>
		</footer>
	</div>
	<script src="~/Scripts/jquery-1.10.2.min.js"></script>
	<script src="~/Scripts/bootstrap.min.js"></script>
</body>
</html>
