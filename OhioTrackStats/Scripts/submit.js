$(document).ready(function () {
    $("#newAthlete").hide();
    $("#distanceContainer").hide();
    
    $("#athlete").change(function () {
        var valueSelected = this.value;
        if (valueSelected === "-- New Athlete --") {
            $("#newAthlete").show();
        } else {
            $("#newAthlete").hide();
        }
    });

    $("#event").change(function () {
        var valueSelected = this.value;
        if (isMaleOnly(valueSelected)) {
            $("#gender option:contains('Female')").prop("disabled", true);
            $("#gender option:contains('Male')").prop("disabled", false);
            $("#gender option:contains('Male')").prop("selected", true);
        } else if (isFemaleOnly(valueSelected)) {
            $("#gender option:contains('Male')").prop("disabled", true);
            $("#gender option:contains('Female')").prop("disabled", false);
            $("#gender option:contains('Female')").prop("selected", true);
        }

        if (isRunningEvent(valueSelected)) {
            $("#timeContainer").show();
            $("#distanceContainer").hide();
        } else if (isThrowingEvent(valueSelected)) {
            $("#distanceContainer").show();
            $("#timeContainer").hide();
            $("#distanceContainerHeader").text("Distance");
        } else if (isJumpingEvent(valueSelected)) {
            $("#distanceContainer").show();
            $("#timeContainer").hide();
            $("#distanceContainerHeader").text("Height");
        }

        function isMaleOnly(value) {
            return $.inArray(value, ["110M Hurdles"]) >= 0;
        };

        function isFemaleOnly(value) {
            return $.inArray(value, ["100M Hurdles"]) >= 0;
        };

        function isRunningEvent(value) {
            return $.inArray(value, ["100M", "200M", "400M", "800M", "1600M", "3200M", "4x100M Relay", "4x200M Relay", "4x400M Relay", "4x800M Relay", "100M Hurdles", "110M Hurdles", "300M Hurdles"]) >= 0;
        }

        function isThrowingEvent(value) {
            return $.inArray(value, ["Shot Put", "Discus"]) >= 0;
        }

        function isJumpingEvent(value) {
            return $.inArray(value, ["Long Jump", "High Jump", "Pole Vault"]) >= 0;
        }
    });
});