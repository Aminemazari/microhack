import React from 'react'
import style from "./style.module.css"
import done from "../assets/done.svg"
import error from "../assets/erroe.svg"
import inProgress from "../assets/inProgress.svg"
const employeInformation = ({pics,username,startDate,endDate,progress,campanyName,campanyLogo}) => {
   var progressPic= "" ; 
    switch (progress){
        case "done":
            progressPic=done; 
            break;
        case "error":
            progressPic=error ; 
            break; 
        case "inprogress":
            progressPic=inProgress;
            break; 
        default:
            break;
    }
  return (
    <div className={style.employeInformation}>
        <section className={style.employeCard}>
            <img src={pics}/>
            <p className={style.employerName}>{username}</p> 
        </section>
        <p className={style.taskDuration}>{startDate}</p>
        <p className={style.taskDuration}>{endDate}</p>
        <img src={progressPic}/>
        <section className={style.campanyinfo}>
            <img src={campanyLogo}/>
            <p className={style.campanyName} >{campanyName}</p>
        </section>
    </div>
  )
}
export default employeInformation 

