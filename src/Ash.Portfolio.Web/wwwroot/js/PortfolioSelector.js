function showInProgressPortfolio() {
	$('.completePortfolio').css('display', 'none');
	$('.gamesPortfolio').css('display', 'none');
	$('.inProgressPortfolio').css('display', 'flex');

	$('.portfolioSelector-completeButton').removeClass("fw-bold");
	$('.portfolioSelector-gamesButton').removeClass("fw-bold");
	$('.portfolioSelector-inProgressButton').addClass("fw-bold");
}

function showCompletePortfolio() {
	$('.inProgressPortfolio').css('display', 'none');
	$('.gamesPortfolio').css('display', 'none');
	$('.completePortfolio').css('display', 'flex');

	$('.portfolioSelector-completeButton').addClass("fw-bold");
	$('.portfolioSelector-gamesButton').removeClass("fw-bold");
	$('.portfolioSelector-inProgressButton').removeClass("fw-bold");
}

function showGamesPortfolio() {
	$('.inProgressPortfolio').css('display', 'none');
	$('.completePortfolio').css('display', 'none');
	$('.gamesPortfolio').css('display', 'flex');

	$('.portfolioSelector-completeButton').removeClass("fw-bold");
	$('.portfolioSelector-gamesButton').addClass("fw-bold");
	$('.portfolioSelector-inProgressButton').removeClass("fw-bold");
}