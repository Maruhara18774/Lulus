import './App.css';
import React, { Component } from 'react';
import 'antd/dist/antd.css';
import {
  BrowserRouter as Router,
  Switch,
  Route
} from "react-router-dom";
import Navbar from './Components/Navbar';
import Home from './Pages/Home';
import PageNotFound from './Pages/NotFound';
import LoginForm from './Pages/Login';

export class App extends Component {
  constructor(props) {
    super(props);
    this.state = {
      logged: false
    }
  }
  callbackLogin = () => {
    this.setState({ logged: true });
  }
  callbackLogout = () => {
    this.setState({ logged: false });
  }
  render() {
    return (
      <div className="App">
        {this.state.logged ?
          <Router>
            <div style={{width:window.innerWidth-20,height:window.innerHeight-5}}>
              <div className="navbar">
                <Navbar callback={this.callbackLogout} />
              </div>
              <div className="content">
                <Switch>
                  <Route path="/" component={Home} />
                  <Route path="**" component={PageNotFound} />
                </Switch>
              </div>
            </div>

          </Router> :
          <LoginForm callback={this.callbackLogin} />
        }
      </div>
    )
  }
}

export default App;
