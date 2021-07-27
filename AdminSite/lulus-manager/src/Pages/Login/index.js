import React, { Component } from 'react';
import './index.css';
import { Form, Input, Button, Checkbox, Typography  } from 'antd';
import {SetToken} from '../../HttpHelper/HttpHelper';
import axios from 'axios';
const {Title} = Typography;


export class LoginForm extends Component {
    constructor(props) {
        super(props)

        this.state = {

        }
    }

    submitHandler = async (value) => {
        const data ={
            username: value.username,
            password: value.password,
            rememberMe: value.remember
        }
        /*
        await axios.post('https://localhost:44354/api/User/Authenticate',data).then(
            response=>{
                if(response.ok){
                    token = response.data;
                    this.props.callback();
                }
                else{
                    alert("Wrong login info.")
                }
            }
        )
        */
        SetToken("eyJhbGciOiJIUzI1NiIsInR5");
        this.props.callback();
    }
    render() {
        return (
            <div id="form-wrap">
                <Form
                    name="basic"
                    initialValues={{ remember: true }}
                    onFinish={this.submitHandler}
                >
                    <Form.Item wrapperCol={{ offset: 9, span: 16 }}>
                        <Title>Login</Title>
                    </Form.Item>
                    <Form.Item
                        label="Username"
                        name="username"
                        rules={[{ required: true, message: 'Please input your username!' }]}
                    >
                        <Input className="custom-input"/>
                    </Form.Item>

                    <Form.Item
                        label="Password"
                        name="password"
                        rules={[{ required: true, message: 'Please input your password!' }]}
                    >
                        <Input.Password className="custom-input" />
                    </Form.Item>

                    <Form.Item name="remember" valuePropName="checked">
                        <Checkbox>Remember me</Checkbox>
                    </Form.Item>

                    <Form.Item wrapperCol={{ offset: 10, span: 16 }}>
                        <Button type="primary" htmlType="submit">
                            Login
                        </Button>
                    </Form.Item>
                </Form>
            </div>

        )
    }
}

export default LoginForm;
