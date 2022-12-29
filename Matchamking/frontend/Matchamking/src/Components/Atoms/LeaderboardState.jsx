import React from 'react'
import styled from 'styled-components'
import equal from '../../assets/bx-minus.svg'
import up from '../../assets/bx-chevron-up.svg'
import down from '../../assets/bx-chevron-down.svg'

const State = styled.div`
    width: 20%;
    display: flex;
    color: #808080;
    justify-content: center;
    align-items: center;
    font-size: 12px;
`
const StatusIcon = styled.img`
    width: 40%;
`

const LeaderboardState = ({state}) => {
    if (state > 0)
    {
        return (
            <State>
                <StatusIcon src={up}></StatusIcon>
                {state}
            </State>
        )
    }
    else if (state === 0)
    {
        return(
            <State>
                <StatusIcon src={equal}></StatusIcon>
                0
            </State>
        )
    }
    else
    {
        return(
            <State>
                <StatusIcon src={down}></StatusIcon>
                {state}
            </State>
        )
    }
}

export default LeaderboardState