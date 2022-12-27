import React, {useState}from 'react'
import BackArrow from '../Components/Atoms/BackArrow'
import MatchmakingManagement from '../Components/Organisms/MatchmakingManagement'
import { useNavigate } from 'react-router-dom'
import MatchmakeButton from '../Components/Atoms/MatchmakeButton'

const Matchmaking = () => {
  // 3 subviews
  const [ subView, setSubView ] = useState(0);

  return (
    <>
    {
      subView === 0 ?
        <>
          <BackArrow navigate={'/'}></BackArrow>
          <MatchmakingManagement/>
          <MatchmakeButton></MatchmakeButton>
        </> 
      :
        <>
        </>
    }
    {
      subView === 1 ?
        <>
        </>
      :
        <>
        </>
    }
    {
      subView === 2 ?
        <>
        </>
      :
        <>
        </>
    }
    </>
    )
}

export default Matchmaking