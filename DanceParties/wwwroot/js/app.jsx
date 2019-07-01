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
        return <div>
            <p>танец: <b>{this.state.data.dance}</b></p>
            <p>место: {this.state.data.place}</p>
            <p>адрес: {this.state.data.address}</p>
            <p>город: {this.state.data.city}</p>
            <p><button onClick={this.onClick}>Удалить</button></p>
        </div>;
    }
}

class PartyForm extends React.Component {

    constructor(props) {
        super(props);
        this.state = { dance: "", place: "", address: "", city: "" };

        this.onSubmit = this.onSubmit.bind(this);
        this.onDanceChange = this.onDanceChange.bind(this);
        this.onPlaceChange = this.onPlaceChange.bind(this);
        this.onAddressChange = this.onAddressChange.bind(this);
        this.onCityChange = this.onCityChange.bind(this);
    }
    onDanceChange(e) {
        this.setState({ dance: e.target.value });
    }
    onPlaceChange(e) {
        this.setState({ place: e.target.value });
    }
    onAddressChange(e) {
        this.setState({ address: e.target.value });
    }
    onCityChange(e) {
        this.setState({ city: e.target.value });
    }
    onSubmit(e) {
        e.preventDefault();
        var partyDance = this.state.dance.trim();
        var partyPlace = this.state.place;
        var partyAddress = this.state.address;
        var partyCity = this.state.city;
        if (!partyDance || !partyPlace || !partyAddress || !partyCity) {
            return;
        }
        this.props.onPartySubmit({ dance: partyDance, place: partyPlace, address: partyAddress, city: partyCity });
        this.setState({ dance: "", place: "", address: "", city: "" });
    }
    render() {
        return (
            <form onSubmit={this.onSubmit}>
                <p>
                    <input type="text"
                        placeholder="Dance"
                        value={this.state.dance}
                        onChange={this.onDanceChange} />
                </p>
                <p>
                    <input type="text"
                        placeholder="Place"
                        value={this.state.place}
                        onChange={this.onPlaceChange} />
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
                <input type="submit" value="Сохранить" />
            </form>
        );
    }
}


class PartysList extends React.Component {

    constructor(props) {
        super(props);
        this.state = { partys: [] };

        this.onAddParty = this.onAddParty.bind(this);
        this.onRemoveParty = this.onRemoveParty.bind(this);
    }
    // загрузка данных
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
    // добавление объекта
    onAddParty(party) {
        if (party) {

            var data = JSON.stringify({ "dance": party.dance, "place": party.place, "address": party.address, "city": party.city });
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
    // удаление объекта
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
        return <div>
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
    <PartysList apiUrl="/api/parties" />,
    document.getElementById("content")
);