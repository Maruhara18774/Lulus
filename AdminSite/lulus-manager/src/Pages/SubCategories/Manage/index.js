import React, { Component } from 'react';
import './index.css';
import { Form, Input, Button, Checkbox, Typography  } from 'antd';
import {withRouter} from 'react-router-dom';
const {Title} = Typography;

export class ManageSubCategory extends Component {
    constructor(props) {
        super(props);
        this.state = {
             isCreate: (this.props.match.params.id == undefined)
        }
    }
    goPreviousPage(){
        this.props.history.goBack();
    }
    render() {
        return (
            <div>
                <Form
                    name="basic"
                    initialValues={{ remember: true }}
                    onFinish={this.submitHandler}
                >
                    <Form.Item>
                        {this.state.isCreate?<Title>Create Subcategory</Title>:<Title>Edit Subcategory</Title>}
                    </Form.Item>
                    <Form.Item
                        label="Subcategory's name:"
                        name="name"
                        rules={[{ required: true, message: 'Please input Subcategory name!' }]}
                    >
                        <Input className="custom-input"/>
                    </Form.Item>
                    <Form.Item wrapperCol={{ offset: 10, span: 16 }}>
                        {this.state.isCreate?
                        <Button type="primary" htmlType="submit">Create</Button>:
                        <Button type="primary" htmlType="submit">Save</Button>}
                        <Button type="primary" style={{marginLeft:"10px"}} onClick={()=>this.goPreviousPage()}>Go back</Button>
                    </Form.Item>
                </Form>
            </div>
        )
    }
}

export default withRouter(ManageSubCategory);
