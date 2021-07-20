import React, { Component } from 'react';
import './index.css';
import {Form, Input, Button} from 'antd';

export class EditSubCategoryFrom extends Component {
    constructor(props) {
        super(props)
    
        this.state = {
             subcateInfor: {},
             newName: ""
        }
    }
    UpdateName= (value) =>{
        
    }
    render() {
        return (
            <div>
                <From onFinish = {this.UpdateName}>
                    <Form.Item label="Sub-category's name: " name="name">
                        <Input defaultValue="..."/>
                    </Form.Item>
                    <Form.Item>
                        <Button type="primary" htmlType="submit">
                            Save
                        </Button>
                    </Form.Item>
                </From>
            </div>
        )
    }
}

export default EditSubCategoryFrom
