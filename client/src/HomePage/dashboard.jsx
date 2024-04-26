import style from "./style/dashboard.module.css"
import bar from "../assets/Bar Chart Border Radius.svg"
import TaskesBar from '../componenet/taskesBar'
import SearchBar from '../componenet/searchBar'
import notification from "../assets/Bell_pin.svg"
import Profilecard from "../componenet/profilecard"
import * as React from 'react';
import dayjs from 'dayjs';
import { DemoContainer } from '@mui/x-date-pickers/internals/demo';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import { DateField } from '@mui/x-date-pickers/DateField';
import off from "../assets/off.svg"
import ButtonWithIcons from "../componenet/buttonWithIcons"
import time from "../assets/Leading Icon.svg"
import done from "../assets/Leading Icon2.svg"
import error from "../assets/Leading Icon3.png"
import EmployeInformation from "../componenet/employeInformation.jsx"
import photo from "../assets/female.svg"
import logo from "../assets/campanylogo.svg"
import photo1 from "../assets/10.png"
import  uc from "../assets/uc.svg"

const dashboard = ({cliked}) => {
  const [value, setValue] = React.useState(dayjs('2024-04-27'));

  return (
    <div className={`${style.dashboard} ${!cliked ? style.not_display: ''}`}>
      
      <section className={style.firstCountainer}>
        <p className={style.dashboard}>Dashboard</p>
        <div className={style.barCountainer}>
          <img src={bar}></img>
          <TaskesBar taskStatus={"Task Queue"} taskTache={154}/>
          <TaskesBar taskStatus={"Finiched Tasks"} taskTache={254}/>
          <TaskesBar taskStatus={"Task Request"} taskTache={94}/>
        </div>
      </section>  
      <section className={style.mainCountainer}>
         <nav className={style.Header}>
            <section className={style.searchANDprofile}>
              <SearchBar></SearchBar>
               <mark className={style.profileNotificationAndAccess}>
                   <img src={notification}></img>
                   <Profilecard username={"Amine Mazari "} pics={""} ></Profilecard>
               </mark>
            </section>
            <section className={style.filterHeader}>
              <button className={style.statusbutton}> <img src={off}></img> Satus</button>
              <div className={style.buttonsection}>
               <ButtonWithIcons pics={time} text={"Ongoing"}/>
               <ButtonWithIcons pics={done} text={"Chip"}/>
               <ButtonWithIcons pics={error} text={"Chip"}/>
              </div>
              <button className={style.statusbutton}> <img src={off}></img> Date</button>

              <section className={style.DateField}>
                  <LocalizationProvider dateAdapter={AdapterDayjs}>
                  <DateField label="Date" defaultValue={dayjs('2022-04-17')}
                    InputProps={{ style: {  width: '134px',height:"40px"} }}
                    />
                  </LocalizationProvider>
                  <LocalizationProvider dateAdapter={AdapterDayjs}>
                  <DateField label="Date" defaultValue={dayjs('2022-04-17')}
                    InputProps={{ style: {  width: '134px',height:"40px"} }}
                    />
                   </LocalizationProvider>
            </section>
         </section>
         </nav>
         <section className={style.tableOfEmployer}>
        <div className={style.HeaderOfEmployer}>
        <p className={style.sameTextType}>Employee</p>
        <p className={style.sameTextType}>Start date</p>
        <p className={style.sameTextType}>End date</p>
        <p className={style.sameTextType}>Porgress</p>
        <p className={style.sameTextType}>Company</p>
        </div>
        <div className={style.employerCardes}>
        <EmployeInformation pics={photo} username={"Clara Chen"} startDate={"11/11/2024"} endDate={"12/12/2024"} progress={"done"} campanyName={"Bolt & Gear"} campanyLogo={logo} />
        <EmployeInformation pics={photo1} username={"Jane Doe"} startDate={"11/11/2024"} endDate={"12/12/2024"} progress={"inprogress"} campanyName={"TechWizes "} campanyLogo={uc} />
        <EmployeInformation pics={photo} username={"Clara Chen"} startDate={"11/11/2024"} endDate={"12/12/2024"} progress={"done"} campanyName={"Bolt & Gear"} campanyLogo={logo} />
        <EmployeInformation pics={photo1} username={"Jane Doe"} startDate={"11/11/2024"} endDate={"12/12/2024"} progress={"inprogress"} campanyName={"TechWizes "} campanyLogo={uc} />
        <EmployeInformation pics={photo} username={"Clara Chen"} startDate={"11/11/2024"} endDate={"12/12/2024"} progress={"done"} campanyName={"Bolt & Gear"} campanyLogo={logo} />
        <EmployeInformation pics={photo1} username={"Jane Doe"} startDate={"11/11/2024"} endDate={"12/12/2024"} progress={"inprogress"} campanyName={"TechWizes "} campanyLogo={uc} />
        <EmployeInformation pics={photo} username={"Clara Chen"} startDate={"11/11/2024"} endDate={"12/12/2024"} progress={"done"} campanyName={"Bolt & Gear"} campanyLogo={logo} />
        <EmployeInformation pics={photo1} username={"Jane Doe"} startDate={"11/11/2024"} endDate={"12/12/2024"} progress={"inprogress"} campanyName={"TechWizes "} campanyLogo={uc} />
        <EmployeInformation pics={photo} username={"Clara Chen"} startDate={"11/11/2024"} endDate={"12/12/2024"} progress={"done"} campanyName={"Bolt & Gear"} campanyLogo={logo} />
        <EmployeInformation pics={photo1} username={"Jane Doe"} startDate={"11/11/2024"} endDate={"12/12/2024"} progress={"inprogress"} campanyName={"TechWizes "} campanyLogo={uc} />
        <EmployeInformation pics={photo} username={"Clara Chen"} startDate={"11/11/2024"} endDate={"12/12/2024"} progress={"done"} campanyName={"Bolt & Gear"} campanyLogo={logo} />
        <EmployeInformation pics={photo1} username={"Jane Doe"} startDate={"11/11/2024"} endDate={"12/12/2024"} progress={"inprogress"} campanyName={"TechWizes "} campanyLogo={uc} />
        <EmployeInformation pics={photo} username={"Clara Chen"} startDate={"11/11/2024"} endDate={"12/12/2024"} progress={"done"} campanyName={"Bolt & Gear"} campanyLogo={logo} />
        <EmployeInformation pics={photo1} username={"Jane Doe"} startDate={"11/11/2024"} endDate={"12/12/2024"} progress={"inprogress"} campanyName={"TechWizes "} campanyLogo={uc} />
        <EmployeInformation pics={photo} username={"Clara Chen"} startDate={"11/11/2024"} endDate={"12/12/2024"} progress={"done"} campanyName={"Bolt & Gear"} campanyLogo={logo} />
        <EmployeInformation pics={photo1} username={"Jane Doe"} startDate={"11/11/2024"} endDate={"12/12/2024"} progress={"inprogress"} campanyName={"TechWizes "} campanyLogo={uc} />

        </div>

      </section>
      </section>



    </div>
  )
}

export default dashboard
