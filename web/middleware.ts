import { NextRequest, NextResponse } from "next/server";

export default async function middleware(request: NextRequest) {
  const accessToken = request.cookies.get("__HOST-accessToken");

  if (!accessToken?.value)
    return NextResponse.redirect(new URL("/auth", request.url));

  return NextResponse.next();
}

export const config = {
  matcher: ["/landlord/:path*"],
};
