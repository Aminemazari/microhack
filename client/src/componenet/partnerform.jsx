import React from 'react'
import style from  "./style.module.css"
const partnerform = ({campanyImage,nameCompany,service}) => {
  return (
    <div className={style.form}>
        <div className={style.formCountainer}>
          <img src={campanyImage}/>
          <p className={style.nameCompany} >{nameCompany}</p>
        </div>
        <p className={style.formService}>{service}</p>
    </div>
  )
}

export default partnerform
