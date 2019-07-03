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
        this.state = { name: "", dance: "", location: "", address: "", city: "", start: ""};

        this.onSubmit = this.onSubmit.bind(this);
        this.onNameChange = this.onNameChange.bind(this);
        this.onDanceChange = this.onDanceChange.bind(this);
        this.onLocationChange = this.onLocationChange.bind(this);
        this.onAddressChange = this.onAddressChange.bind(this);
        this.onCityChange = this.onCityChange.bind(this);
        this.onStartChange = this.onStartChange.bind(this);
    }
    createDanceItems() {
        console.log("createDanceItems");        
        //var selectElement = document.getElementById("dance-select");
        //this.state.dances.map(function (d) {
        //    selectElement.appendChild(<option value={d.id}>{d.name}</option>);
        //}
        //let items = [];
        //this.state.dances.forEach(function (d) {
        //    items.push(<option value={d.id}>{d.name}</option>);
            //});
        //return items;        
    }  
    loadData() {
        //console.log("loadData");
        //var xhr = new XMLHttpRequest();
        //xhr.open("get", this.props.dancesUrl, true);
        //xhr.onload = function () {
        //    var data = JSON.parse(xhr.responseText);
        //    this.setState({ dances: data });
        //    console.log("onload");
        //    this.createDanceItems();
        //}.bind(this);
        //xhr.send();
    }
    componentDidMount() {
        console.log("componentDidMount");
        this.loadData();
    } 
    onNameChange(e) {
        this.setState({ name: e.target.value });
    }
    onDanceChange(e) {
        this.setState({ dance: e.target.value });
    }
    onLocationChange(e) {
        this.setState({ location: e.target.value });
    }
    onAddressChange(e) {
        this.setState({ address: e.target.value });
    }
    onCityChange(e) {
        this.setState({ city: e.target.value });
    }
    onStartChange(e) {
        this.setState({ start: e.target.value });
    }
    onSubmit(e) {
        e.preventDefault();
        var partyName = this.state.name.trim();
        var partyDance = this.state.dance.trim();
        var partyLocation = this.state.location.trim();
        var partyAddress = this.state.address.trim();
        var partyCity = this.state.city.trim();
        var partyStart = this.state.start;
        if (!partyDance || !partyLocation || !partyAddress || !partyCity || !partyStart) {
            return;
        } else {
            alert("Пожалуйста, заполните поля (название не обязательно)");
        }
        this.props.onPartySubmit({ name: partyName, dance: partyDance, location: partyLocation, address: partyAddress, city: partyCity, start: partyStart });
        this.setState({ name: "", dance: "", location: "", address: "", city: "", start: "" });
    }
    render() {
        console.log("render");
        return (
            <form onSubmit={this.onSubmit}>
                <p>
                    <input type="text"
                        placeholder="Name"
                        value={this.state.name}
                        onChange={this.onNameChange} />
                </p>
                <p>
                    <input type="text"
                        placeholder="Dance"
                        value={this.state.dance}
                        onChange={this.onDanceChange} />
                </p>

                <p>
                    <input type="text"
                        placeholder="Location"
                        value={this.state.location}
                        onChange={this.onLocationChange} />
                </p>
                <p>
                    <input type="text"
                        placeholder="Address"
                        value={this.state.address}
                        onChange={this.onAddressChange} />
                </p>
                <p>
                    <input type="text"
                        placeholder="City"
                        value={this.state.city}
                        onChange={this.onCityChange} />
                </p>
                <p>
                    <input type="text"
                        placeholder="Start"
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

            var data = JSON.stringify({ "dance": party.dance, "location": party.location, "address": party.address, "city": party.city, "start": party.start });
            var xhr = new XMLHttpRequest();

            xhr.open("post", this.props.apiUrl, true);
            xhr.setRequestHeader("Content-type", "application/json");
            xhr.onload = function () {
                if (xhr.status == 200) {
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
            <PartyForm onPartySubmit={this.onAddParty} />
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