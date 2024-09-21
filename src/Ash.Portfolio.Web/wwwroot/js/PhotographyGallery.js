var randomNumbers = [];
var totalImageCount = 45;

// Refactor 'allImages' to get all images in the camera directory
var allImages = new Array();

var imageList;

var photoSet = 0;

$(document).ready(function () {
    if (window.location.pathname.indexOf('interests') != -1)
    {
        allImages[0] = "img/camera/lightCinema.png";
        allImages[1] = "img/camera/owenBuilding.png";
        allImages[2] = "img/camera/crookedSpire.png";
        allImages[3] = "img/camera/moorMarket.png";
        allImages[4] = "img/camera/quakerOats.png";
        allImages[5] = "img/camera/sheffieldSheafValleyPathMoss.png";
        allImages[6] = "img/camera/botanicalGardens.png";
        allImages[7] = "img/camera/meStudying.png";
        allImages[8] = "img/camera/meSheffieldLandscape.png";
        allImages[9] = "img/camera/sheffieldLanscape.png";
        allImages[10] = "img/camera/sheafValleyPark.png";
        allImages[11] = "img/camera/nottinghamTrentBridge.png";
        allImages[12] = "img/camera/sheffieldTrainStation.png";
        allImages[13] = "img/camera/nottinghamTrams.png";
        allImages[14] = "img/camera/sheffieldWaterFountain.png";
        allImages[15] = "img/camera/miamiBeachSunrise.png";
        allImages[16] = "img/camera/grandadNearEyam.png";
        allImages[17] = "img/camera/sunsetBrimington.png";
        allImages[18] = "img/camera/fairviewLakeSilhouette.png";
        allImages[19] = "img/camera/sheffieldVarsity.png";
        allImages[20] = "img/camera/westwoodBluebells.png";
        allImages[21] = "img/camera/flatIronNewYork.png";
        allImages[22] = "img/camera/westwoodTrees.png";
        allImages[23] = "img/camera/timeSquareAtNight.png";
        allImages[24] = "img/camera/stonyManShenandoah.png";
        allImages[25] = "img/camera/fairviewSwampWalk.png";
        allImages[26] = "img/camera/grandadRingwoodLake.png";
        allImages[27] = "img/camera/chesterfieldCanalLandscape.png";
        allImages[28] = "img/camera/westonParkSheffield.png";
        allImages[29] = "img/camera/muzzyHandstandCentralPark.png";
        allImages[30] = "img/camera/jackDanielsFactory.png";
        allImages[31] = "img/camera/steelBallsSheffield.png";
        allImages[32] = "img/camera/delawareCanoe.png";
        allImages[33] = "img/camera/sheafValleyPark.png";
        allImages[34] = "img/camera/harryPotterUniversalStudiosFlorida.png";
        allImages[35] = "img/camera/fairviewETC.png";
        allImages[36] = "img/camera/skylineDriveShenandoah.png";
        allImages[37] = "img/camera/miamiBeachPier.png";
        allImages[38] = "img/camera/brimingtonCountrysideEdited.png";
        allImages[39] = "img/camera/miamiBeachGymMorning.png";
        allImages[40] = "img/camera/destinBeachFlorida.png";
        allImages[41] = "img/camera/fairviewPepsiCan.png";
        allImages[42] = "img/camera/sheffieldChineseSideStreet.png";
        allImages[43] = "img/camera/fairviewLakeRidge.png";
        allImages[44] = "img/camera/sunriseRidgeHike.png";

        while (randomNumbers.length < totalImageCount) {
            var randomInt = (Math.floor(Math.random() * totalImageCount) + 1) - 1;
            if (randomNumbers.indexOf(randomInt) === -1) {
                randomNumbers.push(randomInt);
            }
        }

        imageList = $('.photographyTable a').find("img");

        for (var i = 0; i < 15; i++) {
            $(imageList[i]).prop("src", allImages[randomNumbers[i]] + '?' + Math.random());
        }
    }
});

function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}

async function photographyTable_leftArrow() {
    // Fade Out
    $('.photographyTable a').removeClass("imgFadeIn");
    $('.photographyTable a').addClass("imgFadeOut");

    // Sleep
    await sleep(800);

    // Swap Images
    for (var i = 0; i < 15; i++) {
        if (photoSet === 0) {
            $(imageList[i]).attr('src', allImages[randomNumbers[i + 30]]);
        }
        else if (photoSet === 1) {
            $(imageList[i]).attr('src', allImages[randomNumbers[i]]);
        }
        else {
            $(imageList[i]).attr('src', allImages[randomNumbers[i + 15]]);
        }
    }

    // Sleep
    await sleep(200);

    if (photoSet === 0)
        photoSet = 2;
    else if (photoSet === 1)
        photoSet = 0;
    else
        photoSet = 1;

    // Fade In
    $('.photographyTable a').removeClass("imgFadeOut");
    $('.photographyTable a').addClass("imgFadeIn");
}

async function photographyTable_rightArrow() {
    // Fade Out
    $('.photographyTable a').removeClass("imgFadeIn");
    $('.photographyTable a').addClass("imgFadeOut");

    // Sleep
    await sleep(800);

    // Swap Images
    for (var i = 0; i < 15; i++) {
        if (photoSet === 0) {
            $(imageList[i]).attr('src', allImages[randomNumbers[i + 15]]);
        }
        else if (photoSet === 1) {
            $(imageList[i]).attr('src', allImages[randomNumbers[i + 30]]);
        }
        else {
            $(imageList[i]).attr('src', allImages[randomNumbers[i]]);
        }
    }

    // Sleep
    await sleep(200);

    if (photoSet === 0)
        photoSet = 1;
    else if (photoSet === 1)
        photoSet = 2;
    else
        photoSet = 0;

    // Fade In
    $('.photographyTable a').removeClass("imgFadeOut");
    $('.photographyTable a').addClass("imgFadeIn");
}