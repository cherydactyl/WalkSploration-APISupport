function Location(latInput, lonInput, timeInput)
{
    var self = this;
    self.startLat = ko.observable(latInput);
    self.startLon = ko.observable(lonInput);
    self.startTime = ko.observable(timeInput);

    console.log (startLat);
    
}


function LocationViewModel()
{
    var self = this;
    self.currentLocation = ko.observable(new Location);
    
    self.saveLocation = function ()
    {
        var locationModel = ko.mapping.toJS(self.currentLocation);
        ko.utils.postJson("/Home/StartInput", { location: ko.toJS(locationModel) });
    }
}