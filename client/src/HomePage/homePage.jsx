import React,{useState} from 'react'
import NavigationBar from '../componenet/navigationBar'
import style from "./style/home.module.css"
import Dashboard from './dashboard'
import IaCard from '../componenet/iaCard'
import campanylog from "../assets/campanylogo.svg"
const HomePage = () => {
  const [dashboardClick,setDashboardCliked]=useState(true);
  const [singoutClick,setSingoutclicked]=useState(false);
  const [individualClick,setIndividualclicked]=useState(false);
  const [groupClick,setGroupclicked]=useState(false);
  const [documentationClick,setDocumentationclicked]=useState(false);
  const [statistiqueClick,setStatistiqueclicked]=useState(false);
  const [parameterClick,setParameterclicked]=useState(false);
  const handleSingoutonclick=()=>{

    setSingoutclicked(true);
    setDashboardCliked(false);
    setIndividualclicked(false);
    setGroupclicked(false);
    setDocumentationclicked(false);
    setStatistiqueclicked(false);
    setParameterclicked(false);
  }
  const handleDashboardonclick=()=>{
    setDashboardCliked(true); 
    setSingoutclicked(false);
    setIndividualclicked(false);
    setGroupclicked(false);
    setDocumentationclicked(false);
    setStatistiqueclicked(false);
    setParameterclicked(false);
  
  }

  const handleIndividualonclick=()=>{
    setDashboardCliked(false); 
    setSingoutclicked(false);
    setIndividualclicked(true);
    setGroupclicked(false);
    setDocumentationclicked(false);
    setStatistiqueclicked(false);
    setParameterclicked(false);  
  }
  const handleDocumentationonclic=()=>{
    setDashboardCliked(false); 
    setSingoutclicked(false);
    setIndividualclicked(false);
    setGroupclicked(false);
    setDocumentationclicked(true);
    setStatistiqueclicked(false);
    setParameterclicked(false);  
  }
  const handleGrouponclick=()=>{
    setDashboardCliked(false); 
    setSingoutclicked(false);
    setIndividualclicked(false);
    setGroupclicked(true);
    setDocumentationclicked(false);
    setStatistiqueclicked(false);
    setParameterclicked(false);   
  }
 const handleStatistiqueonclick =()=>{
  setDashboardCliked(false); 
  setSingoutclicked(false);
  setIndividualclicked(false);
  setGroupclicked(false);
  setDocumentationclicked(false);
  setStatistiqueclicked(true);
  setParameterclicked(false); 
 }
 const handleParameteronclick =()=>{
  setDashboardCliked(false); 
  setSingoutclicked(false);
  setIndividualclicked(false);
  setGroupclicked(false);
  setDocumentationclicked(false);
  setStatistiqueclicked(false);
  setParameterclicked(true); 
 }
 
  return (
    <div className={style.hero}>
     <NavigationBar dashboardCliked={dashboardClick} singoutonclick={handleSingoutonclick} singoutclicked={singoutClick} individualclicked={individualClick} groupclicked={groupClick} documentationclicked={documentationClick} statistiqueclicked={statistiqueClick} parameterclicked={parameterClick} dashboardonclick={handleDashboardonclick} individualonclick={handleIndividualonclick} documentationonclick ={handleDocumentationonclic} grouponclick={handleGrouponclick} statistiqueonclick={handleStatistiqueonclick} parameteronclick={handleParameteronclick} /> 
  <Dashboard cliked={dashboardClick}/>

    
    </div>
  )
}

export default HomePage
