var app = angular.module('myApp', ['ui.calendar']);
app.controller('myNgController', ['$scope', '$http', 'uiCalendarConfig', function ($scope, $http, uiCalendarConfig)
{
    
    $scope.SelectedEvent = null;
    var isFirstTime = true;

    $scope.events = [];
    $scope.eventSources = [$scope.events];
    
    
    //Load events from server
    function MakehttpCall(Sid)
    {
       
        $http.get('/CustomerSupport/GetF2FMeetings', {
            cache: false,
            params: { staffID: Sid }
        }).then(function (data) {
            $scope.events.slice(0, $scope.events.length);
            angular.forEach(data.data, function (value) {
                $scope.events.push({
                    title: value.course.courseTitle,
                    description: "Meeting with " + value.interaction.customer.firstName + "," + value.interaction.customer.lastName,
                    start: new Date(value.faceToFaceMeetingDateTime),
                    end: CalculateEndTime(value.faceToFaceMeetingDateTime, value.allotedTimeInMinutes),//new Date(value.FaceToFaceMeetingDateTime)
                    allDay: value.IsFullDay,
                    stick: true
                });
            });
        });
    }
    function CalculateEndTime(strdate,minToadd)
    {
        var d = new Date(strdate);
        f = new Date(d.getTime());
        d.setMinutes(d.getMinutes() + parseInt(minToadd));
        return d;

    }
    //uiCalendarConfig.calendars.myCalendar.fullCalendar('gotoDate', now);
    //configure calendar
    $scope.uiConfig = {
        calendar: {
            height: 450,
            editable: true,
            displayEventTime: true,
            header: {
                left: 'month basicWeek basicDay agendaWeek agendaDay',
                center: 'title',
                right:'today prev,next'
            },
            eventClick: function (event) {
                $scope.SelectedEvent = event;
            },
            eventAfterAllRender: function () {
                if ($scope.events.length > 0 && isFirstTime) {
                    //Focus first event
                    uiCalendarConfig.calendars.myCalendar.fullCalendar('gotoDate', $scope.events[0].start);
                    isFirstTime = false;
                }
            }
        }
    };


    $("#F2FMeetingDate").on("dp.change",
        function (e)
        {
            //$('#datetimepicker7').data("DateTimePicker").minDate(e.date);
        uiCalendarConfig.calendars.myCalendar.fullCalendar('gotoDate', e.date._d);
        }
    );


    $(function(){

        $("#SelectedStaffID").change(function() {

            var t = $(this).val();
            $scope.events.splice(0, $scope.events.length)
            MakehttpCall(t);
            

        });
    });

}])