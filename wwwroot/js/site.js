//Code for Artifact Found Dynamic Input Hidden Fields
function yesnoCheck() {
    if (document.getElementById('artifactFoundY').checked) {
        document.getElementById('ifYes').style.display = 'block';
    } else {
        document.getElementById('ifYes').style.display = 'none';
    }
}

//Code for Hair Taken Dynamic Input Hidden Fields
function yesnoCheck2() {
    if (document.getElementById('hairTakenY').checked) {
        document.getElementById('ifYes2').style.display = 'grid';
    } else {
        document.getElementById('ifYes2').style.display = 'none';
    }
}

//Code for Soft Tissue Taken Dynamic Input Hidden Fields
function yesnoCheck3() {
    if (document.getElementById('softTissueTakenY').checked) {
        document.getElementById('ifYes3').style.display = 'grid';
    } else {
        document.getElementById('ifYes3').style.display = 'none';
    }
}

//Code for Bone Taken Dynamic Input Hidden Fields
function yesnoCheck4() {
    if (document.getElementById('boneTakenY').checked) {
        document.getElementById('ifYes4').style.display = 'grid';
    } else {
        document.getElementById('ifYes4').style.display = 'none';
    }
}

//Code for Tooth Taken Dynamic Input Hidden Fields
function yesnoCheck5() {
    if (document.getElementById('toothTakenY').checked) {
        document.getElementById('ifYes5').style.display = 'grid';
    } else {
        document.getElementById('ifYes5').style.display = 'none';
    }
}

//Code for Textile Taken Dynamic Input Hidden Fields
function yesnoCheck6() {
    if (document.getElementById('textileTakenY').checked) {
        document.getElementById('ifYes6').style.display = 'grid';
    } else {
        document.getElementById('ifYes6').style.display = 'none';
    }
}

//Code for File Upload Dynamic Input Hidden Button
function yesnoCheckFile() {
    if (document.getElementById('fileUpload').checked) {
        document.getElementById('ifYesFile').style.display = 'grid';
    } else {
        document.getElementById('ifYesFile').style.display = 'none';
    }
}
