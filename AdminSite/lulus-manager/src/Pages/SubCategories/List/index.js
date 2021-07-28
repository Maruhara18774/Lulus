import { Table, Space,Button } from 'antd';
import React, { Component } from 'react';
import './index.css';
import SampleSubCategory from '../../../sample-data/subcategory.json';
import {withRouter} from 'react-router-dom';
import {Post} from '../../../HttpHelper/HttpHelper';

export class ListSubCategories extends Component {
    constructor(props) {
        super(props)
        // Get id by: this.props.match.params.id
        this.state = {
             dataSource: SampleSubCategory,
             columns: []
        }
    }
    async componentDidMount(){
        // Note
        // Axios get data here with this.props.cateID
        this.state.columns = [
            {
            title: 'Sub-category name',
            dataIndex: 'name',
            key: 'name',
          },
          {
            title: 'Action',
            key: 'action',
            render: (text, record) => (
                <Space size="middle">
                    <p className= "actionBtn" onClick={()=>this.editSubCate(record.id)}>Edit</p>
                    <p onClick={()=>this.deleteSubCate(record.id)} className="actionBtn">Delete</p>
                </Space>
              ),
          },
        ]
        var result = await Post(this.props.token,'/SubCategory/GetList',{
            categoryID: this.props.match.params.id
        })
        if(result.status == 200){
            this.state.dataSource = result.data;
        }
        this.setState(this);
    }
    createSubCate(){
        this.props.history.push("/manageSubCategory");
    }
    deleteSubCate(key){
        // Check key have products, if not allow delete
    }
    editSubCate(key){
        this.props.history.push("/manageSubCategory/"+key);
    }
    goBackPrevious(){
        this.props.history.goBack();
    }
    render() {
        return (
            <div>
                <Button type="primary" shape="round" className="btnPosition" onClick = {()=>this.createSubCate()}>
                    New Subcategory +
                </Button>
                <Table dataSource={this.state.dataSource} columns = {this.state.columns}/>
                <Button type="primary" shape="round" onClick={()=>this.goBackPrevious()} className="btnPosition">Go back</Button>
            </div>
        )
    }
}

export default withRouter(ListSubCategories)
