import { Table } from 'antd';
import React, { Component } from 'react';
import SampleCategory from '../../../sample-data/category.json';
import './index.css';
import { withRouter } from "react-router-dom";

export class ListCategories extends Component {
    constructor(props) {
        super(props);
        this.state = {
             dataSource: SampleCategory,
             columns: []
        }
    }
    viewListSubCate(id){
      this.props.history.push("/listSubCategory/"+id);
    }
    async componentDidMount(){
        this.state.columns = [
            {
            title: 'Category name',
            dataIndex: 'name',
            key: 'name',
          },
          {
            title: 'Action',
            key: 'action',
            render: (text, record) => (
                <>
                  <p onClick={()=> this.viewListSubCate(record.id)} className="actionBtn">View list subcategories</p>
                </>
              ),
          },
        ]
        await this.setState(this);
    }
    render() {
        return (
            <div>
                <Table dataSource={this.state.dataSource} columns = {this.state.columns}/>
            </div>
        )
    }
}

export default withRouter(ListCategories)
