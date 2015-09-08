function Location(latInput, lonInput, timeInput)
{
    var self = this;
    self.startLat = ko.observable(latInput);
    self.startLon = ko.observable(lonInput);
    self.startTime = ko.observable(timeInput);
}

function CurrentLocationViewModel()
{
    var self = this;
    self.currentLocation = ko.observable(new Location(85.122, 44.222, 15));
    
    self.saveLocation = function ()
    {
        var locationModel = ko.mapping.toJS(self.currentLocation);
        ko.utils.postJson("/Home/SaveLocation", {location: locationModel});
    }
}