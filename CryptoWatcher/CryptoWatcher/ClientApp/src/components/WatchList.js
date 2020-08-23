import React, { Component } from 'react';
import { Form, Button, Row, Col} from "react-bootstrap";


export class WatchList extends Component {

    constructor(props) {
        super(props);
        this.state = {
            selectedValue: 'BTC',
            watchListForSelect: [],
            watchtListSelected: [],
            watchListData: [],
            loading: true,
        };
    }


    componentDidMount() {
        Promise.all([
            this.getCurrencies(),
            this.getWatchListFormLocalStorage()
        ]).then(() => {
            this.refreshWatchList()
        })

        setInterval(() => { console.log("Refersh"); this.refreshWatchList(); }, 5000)
    }

    handleChangeState = (e) => {
        let coin = this.state.watchListForSelect.find(function (post, index) {
            if (post.fullName === e.target.value)
                return true;
        });
        this.setState({ selectedValue: coin.name });
    }

    getWatchListFormLocalStorage = () => {
        if (localStorage.getItem("watchListSelected")) {
            this.setState({ watchtListSelected: JSON.parse(localStorage.getItem("watchListSelected")) })
        }
    }

    refreshWatchList = () => {
        this.getMultipleCurrencyInfo(this.state.watchtListSelected).then(result => {
            this.setState({ watchListData: result });
        })
    }

    clearCryptoWatchList = () => {
        this.setState({ watchtListSelected: [] })
        this.setState({ watchListData: [] })
        localStorage.removeItem('watchListSelected');
    }

    addCryptoToWatchList = () => {
        let selecetdValue = this.state.selectedValue;

        if (!(this.state.watchtListSelected.some(x => x === selecetdValue))) {
            let tempList = this.state.watchListData;
            let tempListSelected = this.state.watchtListSelected;

            this.getSingleCurrencyInfo(selecetdValue).then(result => {
                tempListSelected.push(selecetdValue);
                tempList.push(result);
                this.setState({ watchtListSelected: tempListSelected });
                this.setState({ watchListData: tempList });
                localStorage.setItem('watchListSelected', JSON.stringify(tempListSelected));
            })
        }
    }

    static renderWatchListTable(watchList) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Price</th>
                        <th>Volume (24h)</th>
                        <th>Change (24h)</th>
                    </tr>
                </thead>
                <tbody>
                    {watchList.map(cryptoCurrency =>
                        <tr key={cryptoCurrency.Name}>
                            <td>{cryptoCurrency.Name}</td>
                            <td>{cryptoCurrency.Info.Price}</td>
                            <td>{cryptoCurrency.Info.Volume24hour}</td>
                            <td>{cryptoCurrency.Info.Changepct24hour} %</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.watchListData.length===0
            ? <p><em>Please add crypto currnecy to watchlist...</em></p>
            : WatchList.renderWatchListTable(this.state.watchListData);

        return (
            <div>
                <h1 id="tabelLabel" >Your Crypto Watchlist</h1>
                <p>Here, you can add your favourite crypto currency to your private watchlist</p>

                < div >
                    <Row>
                        <Col>   
                            <Form>
                                <Form.Group controlId="exampleForm.SelectCustom">
                                    <Form.Label>Add crypto currency to watch list</Form.Label>
                                    <Row>
                                        <Col>
                                            <Form.Control
                                                as="select"
                                                onChange={this.handleChangeState}>
                                                {this.state.watchListForSelect.map(currnecyEntity =>
                                                    <option key={currnecyEntity.name}>{currnecyEntity.fullName}</option>)}

                                            </Form.Control>
                                        </Col>
                                        <Col>
                                            <Button variant="primary" onClick={this.addCryptoToWatchList} active>Add</Button>{' '}
                                            <Button variant="danger" onClick={this.clearCryptoWatchList} active>Clear</Button>{' '}
                                        </Col>
                                    </Row>
                                </Form.Group>
                            </Form>
                        </Col>                        
                    </Row>
                </div >
                {contents}
            </div>
        );
    }

    async getCurrencies() {
        fetch('CurrencyInfo/currnecyList')
            .then(res => res.json())
            .then(json => this.setState({ watchListForSelect: json }))
    }

    async getSingleCurrencyInfo(symbol) {
        return fetch(`CurrencyInfo/singleInfo?symbol=${symbol}`)
            .then(res => res.json());
    }

    async getMultipleCurrencyInfo(symbolList) {
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(symbolList)
        }
        return fetch('CurrencyInfo/multipleInfo', requestOptions)
            .then(res => res.json());
    }
}
