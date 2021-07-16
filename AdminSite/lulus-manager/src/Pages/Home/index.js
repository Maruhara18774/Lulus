import React, { Component } from 'react';
import { } from 'antd';
import './index.css';
import { Line } from "react-chartjs-2";

export class Home extends Component {
    render() {
        return (
            <div className="home-wrap">
                <table className="main">
                    <tr>
                        <td rowSpan="3">
                            <div className="card">
                                <Line
                                    data={{
                                        labels: [1500, 1600, 1700, 1750, 1800, 1850, 1900, 1950, 1999, 2050],
                                        datasets: [
                                            {
                                                data: [86, 114, 106, 106, 107, 111, 133, 221, 783, 2478],
                                                label: "Excepted",
                                                borderColor: "#3e95cd",
                                                fill: true
                                            },
                                            {
                                                data: [282, 350, 411, 502, 635, 809, 947, 1402, 3700, 5267],
                                                label: "Reality",
                                                borderColor: "#8e5ea2",
                                                fill: true
                                            }
                                        ]
                                    }}
                                    options={{
                                        title: {
                                            display: true,
                                            text: "Chart"
                                        },
                                        legend: {
                                            display: true,
                                            position: "bottom",
                                        }
                                    }}
                                />
                            </div>

                        </td>
                        <td>
                            <div className="card-2">
                                <p>
                                    Order
                                    <br />
                                    <h2>1</h2>
                                </p>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div className="card-2">
                                <p>
                                    Order
                                    <br />
                                    <h2>1</h2>
                                </p>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div className="card-2">
                                <p>
                                    Order
                                    <br />
                                    <h2>1</h2>
                                </p>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        )
    }
}

export default Home
