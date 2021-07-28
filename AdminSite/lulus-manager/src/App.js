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
import ListCategories from './Pages/Categories/List'
import ListSubCategories from './Pages/SubCategories/List';
import ManageSubCategory from './Pages/SubCategories/Manage'; 
import ListProducts from './Pages/Products/List';
import ManageProduct from './Pages/Products/Manage';
import ManageProductLine from './Pages/ProductLines/Manage';
import ListProductLines from './Pages/ProductLines/List';

export class App extends Component {
  constructor(props) {
    super(props);
    this.state = {
      logged: false,
      token: ""
    }
  }
  callbackLogin = (receiver) => {
    this.setState({ logged: true, token: receiver });
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
                  <Route path="/listCategory" render={()=><ListCategories token={this.state.token}/>} />
                  <Route path="/listSubCategory/:id" render={()=><ListSubCategories token={this.state.token}/>} />
                  <Route path="/manageSubCategory/:id" render={()=><ManageSubCategory token={this.state.token}/>} />
                  <Route path="/manageSubCategory" render={()=><ManageSubCategory token={this.state.token}/>} />
                  <Route path="/listProduct" render={()=><ListProducts token={this.state.token}/>} />
                  <Route path="/manageProduct/:id" render={()=><ManageProduct token={this.state.token}/>}/>
                  <Route path="/manageProduct" render={()=><ManageProduct token={this.state.token}/>}/>
                  <Route path="/listProductLine/:id" render={()=><ListProductLines token={this.state.token}/>}/>
                  <Route path="/manageProductLine/:id" render={()=><ManageProductLine token={this.state.token}/>}/>
                  <Route path="/manageProductLine" render={()=><ManageProductLine token={this.state.token}/>}/>
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
