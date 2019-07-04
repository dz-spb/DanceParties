class Party extends React.Component {

    constructor(props) {
        super(props);
        this.state = { data: props.party };
        this.onClick = this.onClick.bind(this);
    }

    onClick(e) {
        this.props.onRemove(this.state.data);
    }

    render() {    
        var startDate = new Date(this.state.data.start);
        var startString = startDate.toString();

        return <div className='party'>
            <p><b>{this.state.data.name}</b></p>
            <p>танец: <b>{this.state.data.dance}</b></p>
            <p>место: {this.state.data.location}</p>
            <p>адрес: {this.state.data.address}</p>
            <p>город: {this.state.data.city}</p>
            <p>начало: {startString}</p>
            <p><button onClick={this.onClick}>Удалить</button></p>
        </div>;
    }
}

class PartyForm extends React.Component {

    constructor(props) {
        super(props);
        this.state = { name: "", start: "", danceId: -1, locationId: -1, dances: [], locations: [] };

        this.onSubmit = this.onSubmit.bind(this);
        this.onNameChange = this.onNameChange.bind(this);
        this.onDanceIdChange = this.onDanceIdChange.bind(this);
        this.onLocationIdChange = this.onLocationIdChange.bind(this);
        this.onStartChange = this.onStartChange.bind(this);
    }

    createDanceItems() {
        let items = [];
        this.state.dances.forEach(function (d) {
            items.push(<option value={d.id} key={d.id}>{d.name}</option>);
        });
        return items;
    }  

    createLocationItems() {
        let items = [];
        this.state.locations.forEach(function (l) {
            items.push(<option value={l.id} key={l.id}>{l.name}, {l.address}, {l.city}</option>);
        });
        return items;
    }

    loadListData(url, addDataToState, getStateObject, component) {
        var xhr = new XMLHttpRequest();
        xhr.open("get", url, true);
        xhr.onload = function () {
            if (xhr.status == 200) {
                var data = JSON.parse(xhr.responseText);
                var first = data[0];
                var firstId = first == undefined ? -1 : first.id;
                var stateObject = getStateObject(data, firstId);
                addDataToState.call(component, stateObject);
            }
        }.bind(this);
        xhr.send();
    }

    buildDanceState(data, id) {
        return {
            dances: data,
            danceId: id
        };
    }

    buildLocationState(data, id) {
        return {
            locations: data,
            locationId: id
        };
    }

    loadData() {
        this.loadListData(
            this.props.dancesUrl,
            this.setState,
            this.buildDanceState,
            this
        );

        this.loadListData(
            this.props.locationsUrl,
            this.setState,
            this.buildLocationState,
            this
        );  
    }

    componentDidMount() {
        var nameInput = $('input[id="name"]');
        var additionalFillerCount = 5;
        var placeholderLength = nameInput.attr('placeholder').length + additionalFillerCount;
        nameInput.attr('size', placeholderLength);
        $('input[id="start"]').daterangepicker({
            alwaysShowCalendars: true,
            autoUpdateInput: true,
            singleDatePicker: true,
            timePicker: true,
            timePicker24Hour: true,
            timePickerIncrement: 1,
            locale: {
                format: 'YYYY MMMM DD hh:mm'
            }
        });
        this.loadData();
    } 

    onNameChange(e) {
        this.setState({ name: e.target.value });
    }  

    onDanceIdChange(e) {     
        this.setState({ danceId: e.target.value });
    }

    onLocationIdChange(e) {
        this.setState({ locationId: e.target.value });
    }

    onStartChange(e) {
        console.log("onStartChange ", e.target.value);
        this.setState({ start: e.target.value });
    }

    onSubmit(e) {
        e.preventDefault();
        var partyName = this.state.name.trim();
        var partyLocationId = this.state.locationId;
        var partyStart = $("input[id='start']").val();
        this.state.start = partyStart;
        var partyDanceId = this.state.danceId;     
        this.props.onPartySubmit({ name: partyName, locationId: partyLocationId, start: partyStart, danceId: partyDanceId });
        this.setState({ name: "", locationId: -1, start: "", danceId: -1});
    }

    render() {
        return (
            <form onSubmit={this.onSubmit}>
                <p>
                    <input type="text"
                        id="name"
                        placeholder="Название вечеринки (необязательно)"
                        value={this.state.name}
                        onChange={this.onNameChange} />
                </p>
                <p>
                    <select value={this.state.danceId} onChange={this.onDanceIdChange}>
                        {this.createDanceItems()}
                    </select>
                </p>
                <p>
                    <select value={this.state.locationId} onChange={this.onLocationIdChange}>
                        {this.createLocationItems()}
                    </select>
                </p>
                <p>
                    <input type="text"
                        id="start" 
                        placeholder="Выберите время"
                        value={this.state.start}
                        onChange={this.onStartChange} />
                </p>
                <input type="submit" value="Сохранить" />
            </form>
        );
    }
}

class PartiesList extends React.Component {

    constructor(props) {
        super(props);
        this.state = { partys: [] };

        this.onAddParty = this.onAddParty.bind(this);
        this.onRemoveParty = this.onRemoveParty.bind(this);
    }

    loadData() {
        var xhr = new XMLHttpRequest();
        xhr.open("get", this.props.apiUrl, true);
        xhr.onload = function () {
            var data = JSON.parse(xhr.responseText);
            this.setState({ partys: data });
        }.bind(this);
        xhr.send();
    }

    componentDidMount() {  
        this.loadData();
    }

    onAddParty(party) {
        if (party) {
            var data = JSON.stringify({ "name": party.name, "locationId": party.locationId, "start": party.start, "danceId": party.danceId });
            var xhr = new XMLHttpRequest();
            xhr.open("post", this.props.apiUrl, true);
            xhr.setRequestHeader("Content-type", "application/json");
            xhr.onload = function () {
                if (xhr.status == 200 || xhr.status == 201 || xhr.status == 204) {
                    this.loadData();
                }
            }.bind(this);
            xhr.send(data);
        }
    }
    
    onRemoveParty(party) {
        if (party) {
            var url = this.props.apiUrl + "/" + party.id;
            var xhr = new XMLHttpRequest();
            xhr.open("delete", url, true);
            xhr.setRequestHeader("Content-Type", "application/json");
            xhr.onload = function () {
                if (xhr.status == 200) {
                    this.loadData();
                }
            }.bind(this);
            xhr.send();
        }
    }

    render() {
        var remove = this.onRemoveParty;
        return <div className='party-list'>
            <PartyForm onPartySubmit={this.onAddParty} dancesUrl="/api/dances" locationsUrl="/api/locations" />
            <h2>Танцевальные вечеринки</h2>
            <div>
                {
                    this.state.partys.map(function (party) {
                        return <Party key={party.id} party={party} onRemove={remove} />
                    })
                }
            </div>
        </div>;
    }
}

ReactDOM.render(
    <PartiesList apiUrl="/api/parties" />,
    document.getElementById("content")
);