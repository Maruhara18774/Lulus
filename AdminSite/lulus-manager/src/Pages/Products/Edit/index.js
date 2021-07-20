import React, { Component } from 'react';
import './index.css';
import {Form, Input, Button, Select} from 'antd';

export class EditProduct extends Component {
    constructor(props) {
        super(props)
    
        this.state = {
             lsCategory:[],
             lsSubCategory: []
        }
    }
    
    render() {
        return (
            <div>
                <From>
                    <Form.Item label="Name: " name="name">
                        <Input/>
                    </Form.Item>
                    <Form.Item label="Price: " name="price">
                        <Input/>
                    </Form.Item>
                    <Form.Item label="Description: " name="description">
                        <Input.TextArea/>
                    </Form.Item>
                    <Form.Item label="Category">
                        <Select>
                            {this.state.lsCategory.map((val, key) => {
                                return (<Select.Option value="demo">Demo</Select.Option>)
                            })}
                        </Select>
                    </Form.Item>
                    <Form.Item label="Sub-category">
                        <Select>
                            {this.state.lsSubCategory.map((val, key) => {
                                return (<Select.Option value="demo">Demo</Select.Option>)
                            })}
                        </Select>
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

export default EditProduct
