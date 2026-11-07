import { useLayoutEffect, useRef, useState } from 'react'

interface LogoMarkProps {
  fontSize?: number
  className?: string
}

export function LogoMark({ fontSize = 24, className }: LogoMarkProps) {
  const svgRef = useRef<SVGSVGElement>(null)
  const preRef = useRef<SVGTextElement>(null)
  const plugRef = useRef<SVGGElement>(null)
  const postRef = useRef<SVGTextElement>(null)
  const [viewBox, setViewBox] = useState<string | null>(null)
  const [box, setBox] = useState<{ width: number; height: number } | null>(null)

  useLayoutEffect(() => {
    const svg = svgRef.current
    const pre = preRef.current
    const plug = plugRef.current
    const post = postRef.current
    if (!svg || !pre || !plug || !post) return

    const scale = fontSize / 100
    const gap = fontSize * 0.025

    plug.removeAttribute('transform')
    const plugLocal = plug.getBBox()
    const preBox = pre.getBBox()

    const plugX = preBox.x + preBox.width + gap
    const translateX = plugX - plugLocal.x * scale
    plug.setAttribute('transform', `translate(${translateX},0) scale(${scale})`)

    const plugRight = plugX + plugLocal.width * scale
    post.setAttribute('x', String(plugRight + gap))

    const full = svg.getBBox()
    const pad = fontSize * 0.06
    setViewBox(`${full.x - pad} ${full.y - pad} ${full.width + pad * 2} ${full.height + pad * 2}`)
    setBox({ width: full.width + pad * 2, height: full.height + pad * 2 })
  }, [fontSize])

  return (
    <svg
      ref={svgRef}
      className={className}
      aria-label="the plugg"
      viewBox={viewBox ?? undefined}
      width={box?.width}
      height={box?.height}
      style={{ visibility: viewBox ? 'visible' : 'hidden', overflow: 'visible' }}
    >
      <text ref={preRef} x={0} y={0} style={{ fontSize, fontFamily: 'var(--font-logo)', fontWeight: 500, fill: 'currentColor' }}>
        the pl
      </text>
      <g ref={plugRef}>
        <rect x={7} y={-78} width={6} height={27} rx={2} fill="currentColor" />
        <rect x={29} y={-78} width={6} height={27} rx={2} fill="currentColor" />
        <path
          d="M3,-52 h36 a2,2 0 0 1 2,2 v14 a15,15 0 0 1 -15,15 h-8 a15,15 0 0 1 -15,-15 v-14 a2,2 0 0 1 2,-2 z"
          fill="currentColor"
        />
        <path
          d="M11,-19 V-5 A13.5 13.5 0 0 0 38 -5 V-46"
          fill="none"
          stroke="var(--color-volt)"
          strokeWidth={5}
          strokeLinecap="round"
          strokeLinejoin="round"
        />
      </g>
      <text ref={postRef} x={0} y={0} style={{ fontSize, fontFamily: 'var(--font-logo)', fontWeight: 500, fill: 'currentColor' }}>
        gg
      </text>
    </svg>
  )
}
