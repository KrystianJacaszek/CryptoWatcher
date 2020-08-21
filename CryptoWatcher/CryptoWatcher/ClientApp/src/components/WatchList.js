import React, { Component } from 'react';
import { Form, Button, Row, Col} from "react-bootstrap";


export class WatchList extends Component {

    constructor(props) {
        super(props);
        this.state = {
            selectedValue: 'USD',
            watchList: [],
            watchListData: [],
            loading: true,
        };
    }

    componentDidMount() {
        this.populateWatchList()
    }

    handleChangeState = (e) => {
        this.setState({ selectedValue: e.target.value });
    }

    clearCryptoWatchList = () => {
        this.setState({ watchListData: [] })
        console.log(this.state.watchListData);
    }

    addCryptoToWatchList = () => {
        let selecetdValue = this.state.selectedValue;
        console.log(this.getCurrnecyDataAsync(selecetdValue))

        if (!(this.state.watchListData.some(x => x.name === selecetdValue))) {
            let tempList = this.state.watchListData;
            tempList.push(this.getCurrnecyDataAsync(selecetdValue));
            this.setState({ watchListData: tempList })
        }
    }

    static renderWatchListTable(watchList) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Market Cap</th>
                        <th>Price</th>
                        <th>Volume (24h)</th>
                        <th>Circulating Supply</th>
                        <th>Change (24h)</th>
                    </tr>
                </thead>
                <tbody>
                    {watchList.map(cryptoCurrency =>
                        <tr key={cryptoCurrency.name}>
                            <td>{cryptoCurrency.name}</td>
                            <td>{cryptoCurrency.marketCap}</td>
                            <td>{cryptoCurrency.price}</td>
                            <td>{cryptoCurrency.volume}</td>
                            <td>{cryptoCurrency.circulatingSupply}</td>
                            <td>{cryptoCurrency.change}</td>
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
                                                {this.state.watchList.map(currnecyEntity =>
                                                    <option key={currnecyEntity}>{currnecyEntity}</option>)}

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

    getCurrnecyDataAsync(currnecy: string) {
        console.log("Return item:" + currnecy)
        switch (currnecy) {
            default:
                return 0;
                break;
            case "USD":
                return {
                    name: "USD",
                    marketCap: "marketCap",
                    price: "price",
                    volume: "volume",
                    circulatingSupply: "circulatingSupply",
                    change: "change"
                }
                break;
            case "BTC":
                return {
                    name: "BTC",
                    marketCap: "marketCap",
                    price: "price",
                    volume: "volume",
                    circulatingSupply: "circulatingSupply",
                    change: "change"
                }
                break;
            case "EUR":
                return {
                    name: "EUR",
                    marketCap: "marketCap",
                    price: "price",
                    volume: "volume",
                    circulatingSupply: "circulatingSupply",
                    change: "change"
                }
                break;
            case "ETH":
                return {
                    name: "ETH",
                    marketCap: "marketCap",
                    price: "price",
                    volume: "volume",
                    circulatingSupply: "circulatingSupply",
                    change: "change"
                }
                break;
        }
    }

    populateWatchList() {
        this.setState({ watchList: ["BTC", "USD", "EUR", "ETH"] })
    }
}
