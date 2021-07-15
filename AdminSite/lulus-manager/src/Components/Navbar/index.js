import React, { Component } from 'react';
import './index.css';
import { Menu } from 'antd';
import { AppstoreOutlined, MailOutlined, SettingOutlined, DoubleRightOutlined, DoubleLeftOutlined } from '@ant-design/icons';
import logoUrl from '../../Assets/logo/logo.png';

const { SubMenu } = Menu;

export class Navbar extends Component {
    constructor(props) {
        super(props)

        this.state = {
            minimize: false
        }
    }
    changeMinimize = async () => {
        const currentState = this.state.minimize;
        await this.setState({ minimize: !currentState });
    }
    render() {
        if(!this.state.minimize){
            return (
                <Menu
                    onClick={e => this.handleClick(e)}
                    style={{height:"100%"}}
                    mode="inline"
                >
                    <img src={logoUrl} alt="Lulus Logo" height="50" className="header-logo"/>
                    <SubMenu key="sub1" icon={<MailOutlined />} title="Navigation One">
                        <Menu.ItemGroup key="g1" title="Item 1">
                            <Menu.Item key="1">Option 1</Menu.Item>
                            <Menu.Item key="2">Option 2</Menu.Item>
                        </Menu.ItemGroup>
                        <Menu.ItemGroup key="g2" title="Item 2">
                            <Menu.Item key="3">Option 3</Menu.Item>
                            <Menu.Item key="4">Option 4</Menu.Item>
                        </Menu.ItemGroup>
                    </SubMenu>
                    <SubMenu key="sub2" icon={<AppstoreOutlined />} title="Navigation Two">
                        <Menu.Item key="5">Option 5</Menu.Item>
                        <Menu.Item key="6">Option 6</Menu.Item>
                        <SubMenu key="sub3" title="Submenu">
                            <Menu.Item key="7">Option 7</Menu.Item>
                            <Menu.Item key="8">Option 8</Menu.Item>
                        </SubMenu>
                    </SubMenu>
                    <SubMenu key="sub4" icon={<SettingOutlined />} title="Navigation Three">
                        <Menu.Item key="9">Option 9</Menu.Item>
                        <Menu.Item key="10">Option 10</Menu.Item>
                        <Menu.Item key="11">Option 11</Menu.Item>
                        <Menu.Item key="12">Option 12</Menu.Item>
                    </SubMenu>
                    <p onClick={()=>this.changeMinimize()} className="header-button"><DoubleLeftOutlined/> Thu nhỏ </p>
                </Menu>
            )
        }
        else{
            return (
                <Menu
                    onClick={() => this.changeMinimize()}
                    style={{ width: 80, height:"100%" }}
                    mode="inline"
                >
                    <div style= {{marginTop:"20px", marginLeft:"40%"}}>
                        <DoubleRightOutlined onClick={()=>this.changeMinimize()}/>
                    </div>
                    <SubMenu key="sub1" icon={<MailOutlined />} title="Navigation One">
                        <Menu.ItemGroup key="g1" title="Item 1">
                            <Menu.Item key="1">Option 1</Menu.Item>
                            <Menu.Item key="2">Option 2</Menu.Item>
                        </Menu.ItemGroup>
                        <Menu.ItemGroup key="g2" title="Item 2">
                            <Menu.Item key="3">Option 3</Menu.Item>
                            <Menu.Item key="4">Option 4</Menu.Item>
                        </Menu.ItemGroup>
                    </SubMenu>
                    <SubMenu key="sub2" icon={<AppstoreOutlined />} title="Navigation Two">
                        <Menu.Item key="5">Option 5</Menu.Item>
                        <Menu.Item key="6">Option 6</Menu.Item>
                        <SubMenu key="sub3" title="Submenu">
                            <Menu.Item key="7">Option 7</Menu.Item>
                            <Menu.Item key="8">Option 8</Menu.Item>
                        </SubMenu>
                    </SubMenu>
                    <SubMenu key="sub4" icon={<SettingOutlined />} title="Navigation Three">
                        <Menu.Item key="9">Option 9</Menu.Item>
                        <Menu.Item key="10">Option 10</Menu.Item>
                        <Menu.Item key="11">Option 11</Menu.Item>
                        <Menu.Item key="12">Option 12</Menu.Item>
                    </SubMenu>
                </Menu>
            )
        }
    }
}

export default Navbar
