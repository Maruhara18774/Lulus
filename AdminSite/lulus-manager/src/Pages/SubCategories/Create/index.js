import React, { Component } from 'react';
import './index.css';
import {Form, Input, Button} from 'antd';

export class CreateSubCategoryFrom extends Component {
    constructor(props) {
        super(props)
    
        this.state = {
             
        }
    }
    
    render() {
        return (
            <div>
                <From>
                    <Form.Item label="Sub-category's name: " name="name">
                        <Input/>
                    </Form.Item>
                    <Form.Item>
                        <Button type="primary" htmlType="submit">
                            Create
                        </Button>
                    </Form.Item>
                </From>
            </div>
        )
    }
}

export default CreateSubCategoryFrom
