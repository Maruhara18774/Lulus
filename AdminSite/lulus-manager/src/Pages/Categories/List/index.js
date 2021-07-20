import { Table } from 'antd';
import React, { Component } from 'react';
import './index.css';

export class ListCategories extends Component {
    constructor(props) {
        super(props)
    
        this.state = {
             lsCategory: [],
             dataSource: [],
             columns: []
        }
    }
    async componentDidMount(){
        this.state.columns = [
            {
            title: 'Category name',
            dataIndex: 'name',
            key: 'name',
          },
          {
            title: 'Count of subcategories',
            dataIndex: 'name',
            key: 'name',
          },
          {
            title: 'Action',
            key: 'action',
            render: (text, record) => (
                <>
                  <a>View list subcategories</a>
                </>
              ),
          },
        ]
    }
    render() {
        return (
            <div>
                <Table dataSource={this.state.dataSource} columns = {this.state.columns}/>
            </div>
        )
    }
}

export default ListCategories
