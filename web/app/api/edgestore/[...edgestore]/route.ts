import { initEdgeStore } from "@edgestore/server";
import { z } from "zod";
import { createEdgeStoreNextHandler } from "@edgestore/server/adapters/next/app";

const es = initEdgeStore.create();

const edgeStoreRouter = es.router({
  publicImages: es
    .imageBucket()
    .input(
      z.object({
        type: z.enum(["profile", "listing"]),
      })
    )
    .path(({ input }) => [{ type: input.type }]),
});

const handler = createEdgeStoreNextHandler({
  router: edgeStoreRouter,
});

export { handler as GET, handler as POST };

export type EdgeStoreRouter = typeof edgeStoreRouter;
