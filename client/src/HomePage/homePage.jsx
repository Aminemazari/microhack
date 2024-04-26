import React from 'react'
import NavigationBar from '../componenet/navigationBar'
import style from "./style/home.module.css"
import Dashboard from './dashboard'
const homePage = () => {
  return (
    <div className={style.hero}>
     <NavigationBar/> 
     <Dashboard/>
    </div>
  )
}

export default homePage
